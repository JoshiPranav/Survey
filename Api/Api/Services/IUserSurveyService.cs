using System.Threading.Tasks;
using Api.ViewModels;

namespace Api.Services
{
    public interface IUserSurveyService
    {
        Task<int> SaveUserSurveyAsync(UserSurveyViewModel userSurveyViewModel);
    }
}
