using System.Collections.Generic;

namespace Api.ViewModels
{
    public class UserSurveyViewModel
    {
        public string Nickname { get; set; }
        public int SurveyId { get; set; }
        public List<UserAnswerViewModel> UserAnswers { get; set; }
    }
}
