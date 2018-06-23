using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Xunit;

namespace XUnitTestProject1
{
    public class Movies_IntegrationTests
    {
        private readonly HttpClient client_;
        private readonly TestServer testServer_;

        public Movies_IntegrationTests()
        {
            var webHostBuilder = new WebHostBuilder()
                .UseStartup<MoviesHubNew.Startup>();

            testServer_ = new TestServer(webHostBuilder);
            client_ = testServer_.CreateClient();
        }

        [Fact]
        public async Task Movies_Index()
        {
            HttpResponseMessage response = await client_.GetAsync("/Movies");

            // Assert on correct content
            Assert.True(response.IsSuccessStatusCode);
        }

        [Theory]
        [InlineData("Index")]
        [InlineData("About")]
        public async Task Home(string path)
        {
            HttpResponseMessage response = await client_.GetAsync($"/Home/{path}");
        }
    }
}
