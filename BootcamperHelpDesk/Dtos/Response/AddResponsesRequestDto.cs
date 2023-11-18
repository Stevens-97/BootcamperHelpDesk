namespace bootcamper_helpdesk.Dtos.Response
{
    public class AddResponsesRequestDto
    {
        public string? Answer { get; set; }
        public int UserId { get; set; }
        public int QuestionID { get; set; }
        public int SurveryId { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}
