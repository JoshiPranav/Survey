using System.Collections.Generic;
using System.IO;
using System.Linq;
using Api.Data;
using Api.Data.Entities;
using Api.Repositories;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NSubstitute;
using Xunit;

namespace Api.Tests.Repositories
{
    public class SurveyRepositoryTests
    {
        [Fact(Skip = "NSubstitute errors when mocking DBSet on line: _dbContext.Surveys.Returns(mockSurveyDbSet). Need some more time on this.")]
        public void GetOrderedSurveyByIdAsync_When_GetsData_Then_Be_Sorted()
        {
            //Read json and deserialize to survey mock
            var mockJsonPath = Directory.GetCurrentDirectory() + "\\Repositories\\surveydata.json";
            var json = File.ReadAllText(Path.Combine(mockJsonPath));
            var mockSurveys = JsonConvert.DeserializeObject<IEnumerable<Survey>>(json).AsQueryable();

            //mock db set
            DbSet<Survey> mockSurveyDbSet = Substitute.For<DbSet<Survey>, IQueryable<Survey>>();
            ((IQueryable<Survey>)mockSurveyDbSet).Provider.Returns(mockSurveys.Provider);
            ((IQueryable<Survey>)mockSurveyDbSet).Expression.Returns(mockSurveys.Expression);
            ((IQueryable<Survey>)mockSurveyDbSet).ElementType.Returns(mockSurveys.ElementType);
            ((IQueryable<Survey>)mockSurveyDbSet).GetEnumerator().Returns(mockSurveys.GetEnumerator());

            //mock db context
            var dbContext = Substitute.For<SurveyDbContext>(new DbContextOptions<SurveyDbContext>());
            dbContext.Surveys.Returns(mockSurveyDbSet);
            
            //call fn
            var repository = new SurveyRepository(dbContext);
            var orderedSurvey = repository.GetOrderedSurveyByIdAsync(1).Result;
            var firstQuestion = orderedSurvey.SurveyQuestions.First();
            firstQuestion.QuestionText.Should().Be("What is your favourite animal?");
            firstQuestion.SurveyQuestionAnswers.First().AnswerText.Should().Be("Cat");
        }

        [Fact(Skip = "NSubstitute errors when mocking DBSet on line: _dbContext.Surveys.Returns(mockSurveyDbSet). Need some more time on this.")]
        public void SaveUserSurvey_WhenSavesData_DbSetAndDbContext_Receives_Call()
        {
            DbSet<UserSurvey> mockDbSet = Substitute.For<DbSet<UserSurvey>>();
            var dbContext = Substitute.For<SurveyDbContext>(new DbContextOptions<SurveyDbContext>());
            dbContext.UserSurveys.Returns(mockDbSet);
            var repository = new SurveyRepository(dbContext);
            var result = repository.SaveUserSurveyAsync(new List<UserSurvey> { new UserSurvey() }).Result;
            mockDbSet.Received(1).Add(Arg.Any<UserSurvey>());
            dbContext.Received(1).SaveChangesAsync();
        }
    }
}
