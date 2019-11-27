namespace Api.Data.Entities
{
    public class UserSurvey
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public int SurveyId { get; set; }
        public int QuestionId { get; set; }
        public int AnswerId { get; set; }
    }
}
