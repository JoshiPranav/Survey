using System.Threading.Tasks;
using Api.Data.Entities;
using Api.Repositories;
using Api.ViewModels;
using AutoMapper;

namespace Api.Services
{
    public class SurveyService : ISurveyService
    {
        private readonly ISurveyRepository _surveyRepository;
        private readonly IMapper _mapper;
        public SurveyService(ISurveyRepository surveyRepository, IMapper mapper)
        {
            _surveyRepository = surveyRepository;
            _mapper = mapper;
        }
        public async Task<SurveyViewModel> GetSurveyAsync(int id)
        {
            var survey = await _surveyRepository.GetOrderedSurveyByIdAsync(id);
            if (survey == null)
            {
                return null;
            }
            return _mapper.Map<Survey, SurveyViewModel>(survey);
        }
    }
}
