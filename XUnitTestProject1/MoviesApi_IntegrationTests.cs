using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Domain.Context;
using Domain.Interfaces;
using Domain.Models;
using Domain.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using RestEase;
using Xunit;

namespace XUnitTestProject1
{
    public interface IMoviesApi
    {
        [Get("/api/Movies")]
        Task<IList<Movie>> GetAllAsync();

        [Get("/api/Movies/{id}")]
        Task<Movie> GetAsync([Path] int id, [Query("code")] string code);
    }
    public class MyFixture5
    {
        public readonly IMoviesApi Api;
        private IServiceProvider container_;

        public MyFixture5()
        {
            var connection = @"Server=localhost,1433;Database=Movies;Persist Security Info=True;uid=sa;pwd=D1m1tr1s!;ConnectRetryCount=0";

            container_ = new ServiceCollection()
                .AddDbContext<MoviesContext>(options =>
                    options.UseSqlServer(connection))
                .BuildServiceProvider();

            var webHostBuilder = new WebHostBuilder()
                .UseStartup<MoviesApi.Startup>()
                .ConfigureTestServices(services =>
                {
                    services.AddTransient<IPricingService, FakePricingService>();
                });

            //var mockPricingService = new Mock<IPricingService>();

            //mockPricingService
            //    //.SetReturnsDefault(0M);
            //    .Setup(a => a.DiscountPercentage(It.IsAny<string>()))
            //    .Returns(0M);

            var ts = new TestServer(webHostBuilder);
            Api = RestClient.For<IMoviesApi>(ts.CreateClient());
        }

        public T Resolve<T>()
        {
            return container_.GetService<T>();
        }
    }

    public class MoviesApi_IntegrationTests : IClassFixture<MyFixture5>
    {
        private readonly IMoviesApi api_;
        private readonly MoviesContext contx_;

        public MoviesApi_IntegrationTests(MyFixture5 myFixture)
        {
            api_ = myFixture.Api;
            contx_ = myFixture.Resolve<MoviesContext>();
        }

        [Fact]
        public async void GetAllAsync()
        {
            var movies = await api_.GetAllAsync();

            foreach(var m in movies) {
                Assert.True(m.Price > 0);
                Assert.True(m.Title.Length > 0);
            }
        }

        [Fact]
        public async void GetAsync()
        {
            var inceptionMovie = contx_.Movie.FirstOrDefault(m =>
                m.Title == "Inception");

            Assert.NotNull(inceptionMovie);
            Assert.True(inceptionMovie.Price > 0);

            var movie = await api_.GetAsync(inceptionMovie.MovieId, "10xxx");

            Assert.Equal(inceptionMovie.Price, movie.Price);
        }
    }
}
