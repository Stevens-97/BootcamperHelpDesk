namespace bootcamper_helpdesk.Dtos.SurveyQuestion
{
    public class AddSurveyQuestionDto
    {
        public string? SurveyId { get; set; }
        public string? Title { get; set; }
        public string? Question { get; set; }
        public string? QuestionType { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}
