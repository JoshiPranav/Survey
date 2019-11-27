using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data;
using Api.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories
{
    public class SurveyRepository : ISurveyRepository
    {
        private readonly SurveyDbContext _dbContext;

        public SurveyRepository(SurveyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Survey> GetOrderedSurveyByIdAsync(int id)
        {
            return await _dbContext.Surveys.Where(x => x.Id == id)
                .Select(x => new Survey()
                {
                    Id = x.Id,
                    Description = x.Description,
                    SurveyQuestions = x.SurveyQuestions.OrderBy(o => o.SortOrder)
                        .Select(o => new SurveyQuestion
                        {
                            Id = o.Id,
                            QuestionText = o.QuestionText,
                            SortOrder = o.SortOrder,
                            SurveyQuestionAnswers = o.SurveyQuestionAnswers.OrderBy(a => a.SortOrder)
                        })
                }).SingleOrDefaultAsync(x=>x.Id == id);
        }

        public async Task<int> SaveUserSurveyAsync(List<UserSurvey> userSurveys)
        {
            _dbContext.UserSurveys.AddRange(userSurveys);
            return await _dbContext.SaveChangesAsync();
        }
    }
}
