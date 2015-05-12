using System.Data.Entity;

namespace GFS.Models
{
    public class GFSContext : DbContext
    {
        public GFSContext() : base ("GFS")
        {

        }
        public DbSet<Email> Emails { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<FeedbackContainer> FeedbackContainers { get; set; }
        public DbSet<Form> Forms { get; set; }
        public DbSet<FormContainer> FormContainers { get; set; }
        public DbSet<Section> Sections { get; set; }
    }
}