using System;
using System.Collections.Generic;
using TestProject.Data.Entity.Base;

namespace TestProject.Data.Entity {
    public class Group : BaseEntity {
        public string Аbbreviation { get; set; }

        public Guid? CuratorId { get; set; }
        public Curator Curator { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}
