using System;
using System.Net;
using RestSharp;

namespace PlaylistApi.Tests.ApiWrapper
{
	public class RestRequestWrapper
	{
		public T PostRequest<T>(string uri) where T : new()
		{
			return PostRequest<T>(uri, CreateRequest());
		}

		public T PostRequest<T>(IRequestBody requestBody, string uri) where T : new()
		{
			var request = CreateRequest();
			request.AddBody(requestBody);
			return PostRequest<T>(uri, request);
		}

		private static T PostRequest<T>(string uri, IRestRequest request) where T : new()
		{
			var client = new RestClient(uri);
			var response = client.ExecuteAsPost<T>(request, "POST");

			Console.WriteLine("POST {0}", uri);
			
			HandleExceptions(response);

			return response.Data;
		}

		public T GetRequest<T>(string uri) where T : new()
		{
			var request = CreateRequest();
			var client = new RestClient(uri);
			
			Console.WriteLine("GET {0}", uri);

			var response = client.Execute<T>(request);

			HandleExceptions(response);

			return response.Data;
		}

		private static RestRequest CreateRequest()
		{
			var request = new RestRequest {RequestFormat = DataFormat.Json};
			request.AddHeader("content-type", "application/json");
			return request;
		}

		private static void HandleExceptions<T>(IRestResponse<T> response) where T : new()
		{
			if (response.ErrorException != null)
				throw response.ErrorException;

			if (response.StatusCode != HttpStatusCode.OK)
				throw new WebException(response.StatusCode.ToString());
		}
	}
}