using System.Threading.Tasks;
using Api.Controllers;
using Api.Services;
using Api.ViewModels;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using NSubstitute;
using Xunit;

namespace Api.Tests.Controllers
{
    public class UserSurveyControllerTests
    {
        private IUserSurveyService mockService = Substitute.For<IUserSurveyService>();
        private ILogger<UserSurveyController> mockLogger = new NullLogger<UserSurveyController>();
        
       
        [Fact]
        public void PostUserSurveyAsync_When_SavesData_Then_Created()
        {
            mockService.SaveUserSurveyAsync(Arg.Any<UserSurveyViewModel>()).Returns(Task.Run(() => 1));
            var controller = new UserSurveyController(mockService, mockLogger);
            var result = controller.Post(new UserSurveyViewModel()).Result;
            var okResult = result.Should().BeOfType<CreatedResult>().Subject;
        }

        [Fact]
        public void PostUserSurveyAsync_When_NoData_Then_BadRequest()
        {
            mockService.SaveUserSurveyAsync(Arg.Any<UserSurveyViewModel>()).Returns(Task.Run(() => 1));
            var controller = new UserSurveyController(mockService, mockLogger);
            var result = controller.Post(null).Result;
            var badRequestResult = result.Should().BeOfType<BadRequestObjectResult>().Subject;
        }
    }
}
