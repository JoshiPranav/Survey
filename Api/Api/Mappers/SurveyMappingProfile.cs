using Api.Data.Entities;
using Api.ViewModels;
using AutoMapper;
using System.Linq;

namespace Api.Mappers
{
    public class SurveyMappingProfile : Profile
    {
        public SurveyMappingProfile()
        {
            CreateMap<Survey, SurveyViewModel>();
            CreateMap<SurveyQuestion, SurveyQuestionViewModel>();
            CreateMap<SurveyQuestionAnswer, SurveyQuestionAnswerViewModel>();
            //CreateMap<UserSurveyViewModel, UserSurvey>()
            //    .ForMember(us => us.Nickname, usvm => usvm.MapFrom(x=>x.UserChoices.First().)
            //    .ReverseMap();
        }
    }
}
