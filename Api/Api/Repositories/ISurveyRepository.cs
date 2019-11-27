using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Data.Entities;

namespace Api.Repositories
{
    public interface ISurveyRepository
    {
        Task<Survey> GetOrderedSurveyByIdAsync(int id);
        Task<int> SaveUserSurveyAsync(List<UserSurvey> userSurveys);
    }
}
