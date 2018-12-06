using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Data.Entity;

namespace TestProject.DAL.Mapping {
    public class StudentMap : EntityTypeConfiguration<Student> {
        public StudentMap() {
            ToTable("Students");

            HasKey(s => s.Id);

            Property(s => s.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasOptional(s => s.Group).WithMany(g => g.Students).HasForeignKey(s => s.GroupId);
        }
    }
}
