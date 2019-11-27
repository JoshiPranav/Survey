using System.Collections.Generic;

namespace Api.Data.Entities
{
    public class SurveyQuestion
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public int SortOrder { get; set; }
        public IEnumerable<SurveyQuestionAnswer> SurveyQuestionAnswers { get; set; }
    }
}
