namespace PlaylistApi.Tests.ApiWrapper
{
	public class PlaylistRequest : IRequestBody
	{
		public string owner { get; set; }

		public string name { get; set; }
	}
}