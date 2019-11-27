using System.Collections.Generic;

namespace Api.ViewModels
{
    public class SurveyViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<SurveyQuestionViewModel> SurveyQuestions { get; set; }
    }
}
