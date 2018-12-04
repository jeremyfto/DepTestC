using Microsoft.EntityFrameworkCore;
 
namespace ExamCRetake.Models
{
    public class Context : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public Context(DbContextOptions<Context> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Activitys> Activities { get; set; }
        public DbSet<JoinAct> JoinAct { get; set; }
    }
}