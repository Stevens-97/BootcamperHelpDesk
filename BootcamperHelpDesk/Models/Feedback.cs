namespace BootcamperHelpDesk.Models
{
    public class Feedback
    {
        public int ID { get; set; }
        public string Response { get; set; }
        public int UserId { get; set; }
        public int QuestionID { get; set; }
        public int SurveryId { get; set; }
        public DateOnly CreationDate { get; set; }
    }
}
