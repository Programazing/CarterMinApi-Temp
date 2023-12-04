using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace WebApplication1.Tests
{
	public class UserControllerTests
	{
		private WebApplicationFactory<Program> _factory;
		private HttpClient _client;

		[SetUp]
		public void SetUp()
		{
			_factory = new WebApplicationFactory<Program>();
			_client = _factory.CreateClient();
		}

		[TearDown]
		public void TearDown()
		{
			_client.Dispose();
			_factory.Dispose();
		}

		[Test]
		public async Task GetAllUsers_ShouldReturnSuccessStatusCode()
		{
			var response = await _client.GetAsync("/users");
			response.EnsureSuccessStatusCode();
		}
	}
}