namespace bootcamper_helpdesk.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) :base(options) 
        {
            
        }
        public DbSet<Response> Responses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<SurveyQuestion> SurveyQuestions { get; set; }

    }
}
