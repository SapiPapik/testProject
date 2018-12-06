using System.Data.Entity;
using System.Diagnostics;
using TestProject.Data.Entity;
using TestProject.DAL.Mapping;

namespace TestProject.DAL {
    public class GroupsContext : DbContext {
        public GroupsContext() : base("GroupsContext") {
#if DEBUG
            Database.Log = e => Debug.WriteLine(e);
            Configuration.LazyLoadingEnabled = false;
#endif
        }

        public DbSet<Group> Groups { get; set; }
        public DbSet<Curator> Curators { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new CuratorMap());
            modelBuilder.Configurations.Add(new GroupMap());
            modelBuilder.Configurations.Add(new StudentMap());
        }
    }
}
