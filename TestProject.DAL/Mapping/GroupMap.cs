using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Data.Entity;

namespace TestProject.DAL.Mapping {
    public class GroupMap : EntityTypeConfiguration<Group> {
        public GroupMap() {
            ToTable("Groups");
            HasKey(g => g.Id);

            Property(g => g.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasOptional(g => g.Curator).WithMany(c => c.Groups).HasForeignKey(g => g.CuratorId);
            HasMany(c => c.Students).WithOptional(s => s.Group).HasForeignKey(s => s.GroupId);
        }
    }
}
