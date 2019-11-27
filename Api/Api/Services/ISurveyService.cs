using System.Threading.Tasks;
using Api.ViewModels;

namespace Api.Services
{
    public interface ISurveyService
    {
        Task<SurveyViewModel> GetSurveyAsync(int id);
    }
}
