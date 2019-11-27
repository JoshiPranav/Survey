using System.Collections.Generic;
using Api.Data.Entities;
using Api.Repositories;
using Api.Services;
using Api.ViewModels;
using AutoMapper;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Api.Tests.Services
{
    public class UserSurveyServiceTests
    {
        private ISurveyRepository mockRepository = Substitute.For<ISurveyRepository>();

        [Fact]
        public void SaveUserSurveyAsync_When_SavesData_Then_Returns_RecordCount()
        {
            mockRepository.SaveUserSurveyAsync(Arg.Any<List<UserSurvey>>()).Returns(2);
            var service = new UserSurveyService(mockRepository);
            var mockUserSurveyVM = new UserSurveyViewModel
            {
                Nickname = "test",
                SurveyId = 1,
                UserAnswers = new List<UserAnswerViewModel> { new UserAnswerViewModel { QuestionId = 1, AnswerId = 1 } }
            };

            var result = service.SaveUserSurveyAsync(mockUserSurveyVM).Result;
            result.Should().Be(2);
        }
    }
}
