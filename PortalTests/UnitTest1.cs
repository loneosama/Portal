using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Portal.Controllers;
using Portal.Data;
using Portal.Models;
using Xunit;

namespace PortalTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Assert.True(true);
        }
        [Fact]
        public async void TestHomeControllerAndCheckIndexForReturningList()
        {
            //Arrange
            var mock = new Mock<IMovieRepository>();
            var list = new List<Movie>()
            {
                new Movie()
                {
                    ID = 0,
                    Name = "Hello",
                    Rating = 9.2,
                    ReleaseYear = 2012
                    
                },
                new Movie()
                {
                    ID =1,
                    Name = "bye",
                    Rating = 0.2,
                    ReleaseYear = 2010
                }
            };
            mock.Setup(frame => frame.MovieListAsync()).Returns(list);
            IMovieRepository repo = mock.Object;
            var controller = new MoviesController(repo);
            //Act
            var action = controller.Index();
            
            //Assert
            Assert.IsType<ViewResult>(action);
            var result = action as ViewResult;
            var model = result.Model as ICollection<Movie>;
            Assert.Equal(2,model.Count);
            Assert.Equal(list,model);
               
        }
    }
}
