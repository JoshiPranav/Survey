using System.Threading.Tasks;
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
    public class SurveyServiceTests
    {
        private ISurveyRepository mockRepository = Substitute.For<ISurveyRepository>();
        private IMapper mockMapper = Substitute.For<IMapper>();

        [Fact]
        public void GetSurveyAsync_When_GetsData_Then_Ok()
        {
            mockRepository.GetOrderedSurveyByIdAsync(Arg.Any<int>()).Returns(Task.Run(() => new Survey()));
            mockMapper.Map<Survey, SurveyViewModel>(Arg.Any<Survey>()).Returns(new SurveyViewModel());
            var service = new SurveyService(mockRepository, mockMapper);
            var result = service.GetSurveyAsync(1).Result;
            var okResult = result.Should().BeOfType<SurveyViewModel>();
        }

        [Fact]
        public void GetSurveyAsync_When_NullData_Then_ReturnsNull()
        {
            Survey nullModel = null;
            mockRepository.GetOrderedSurveyByIdAsync(Arg.Any<int>()).Returns(Task.Run(() => nullModel));
            mockMapper.Map<Survey, SurveyViewModel>(Arg.Any<Survey>()).Returns(new SurveyViewModel());
            var service = new SurveyService(mockRepository, mockMapper);
            var result = service.GetSurveyAsync(1).Result;
            var okResult = result.Should().BeNull();
        }
    }
}
