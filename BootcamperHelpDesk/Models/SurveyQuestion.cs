﻿namespace bootcamper_helpdesk.Models
{
    public class SurveyQuestion
    {
        public int Id { get; set; }
        public string? SurveyId { get; set; }
        public string? Title { get; set; }
        public string? Question { get; set; }
        public string? QuestionType { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}
