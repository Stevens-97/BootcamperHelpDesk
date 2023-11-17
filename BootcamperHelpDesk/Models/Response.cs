namespace BootcamperHelpDesk.Models
{
    public class Response
    {
        public int Id { get; set; }
        public string? Answer { get; set; }
        public int UserId { get; set; }
        public int QuestionID { get; set; }
        public int SurveryId { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}
