using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Data.Entity;

namespace TestProject.DAL.Mapping {
    public class CuratorMap : EntityTypeConfiguration<Curator> {
        public CuratorMap() {
            ToTable("Curators");

            HasKey(c => c.Id);

            Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasMany(c => c.Groups).WithOptional(g => g.Curator).HasForeignKey(g => g.CuratorId);
        }
    }
}
