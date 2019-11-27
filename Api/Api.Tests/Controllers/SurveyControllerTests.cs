using System;
using System.Threading.Tasks;
using Api.Controllers;
using Api.Services;
using Api.ViewModels;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using Xunit;

namespace Api.Tests.Controllers
{
    public class SurveyControllerTests
    {
        private ISurveyService mockService = Substitute.For<ISurveyService>();
        private ILogger<SurveyController> mockLogger = new NullLogger<SurveyController>();
        
       
        [Fact]
        public void GetSurveyAsync_When_GetsData_Then_Ok()
        {
            mockService.GetSurveyAsync(Arg.Any<int>()).Returns(Task.Run(() => new SurveyViewModel()));
            var controller = new SurveyController(mockService, mockLogger);
            var result = controller.Get(1).Result;
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
        }

        [Fact]
        public void GetSurveyAsync_When_NoData_Then_NotFound()
        {
            SurveyViewModel nullModel = null;
            mockService.GetSurveyAsync(Arg.Any<int>()).Returns(Task.Run(() => nullModel));
            var controller = new SurveyController(mockService, mockLogger);
            var result = controller.Get(1).Result;
            var notFoundResult = result.Should().BeOfType<NotFoundObjectResult>().Subject;
        }

        [Fact]
        public void GetSurveyAsync_When_Failed_Then_BadRequest()
        {
            mockService.GetSurveyAsync(Arg.Any<int>()).Throws(new Exception());
            var controller = new SurveyController(mockService, mockLogger);
            var result = controller.Get(1).Result;
            var badReqResult = result.Should().BeOfType<BadRequestObjectResult>().Subject;
        }
    }
}
