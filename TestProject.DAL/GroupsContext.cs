using System.Data.Entity;
using TestProject.Data.Entity;

namespace TestProject.DAL
{
    public class GroupsContext : DbContext
    {
        public GroupsContext() : base("GroupsContext")
        {

        }

        public DbSet<Group> Groups { get; set; }
        public DbSet<Curator> Curators { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
