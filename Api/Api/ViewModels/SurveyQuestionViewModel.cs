using System.Collections.Generic;

namespace Api.ViewModels
{
    public class SurveyQuestionViewModel
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public int SortOrder { get; set; }
        public ICollection<SurveyQuestionAnswerViewModel> SurveyQuestionAnswers { get; set; }
    }
}