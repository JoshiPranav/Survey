using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Data.Entities;
using Api.Repositories;
using Api.ViewModels;
using AutoMapper;

namespace Api.Services
{
    public class UserSurveyService : IUserSurveyService
    {
        private readonly ISurveyRepository _surveyRepository;
        public UserSurveyService(ISurveyRepository surveyRepository)
        {
            _surveyRepository = surveyRepository;
        }
        public async Task<int> SaveUserSurveyAsync(UserSurveyViewModel userSurveyViewModel)
        {
            var userSurveyList = new List<UserSurvey>();
            var userNickname = userSurveyViewModel.Nickname;
            var surveyId = userSurveyViewModel.SurveyId;
            foreach (var surveyVM in userSurveyViewModel.UserAnswers)
            {
                userSurveyList.Add(new UserSurvey
                {
                    Nickname = userNickname,
                    SurveyId = surveyId,
                    QuestionId = surveyVM.QuestionId,
                    AnswerId = surveyVM.AnswerId
                });
            }
            return await _surveyRepository.SaveUserSurveyAsync(userSurveyList);
        }
    }
}
