using System;
using System.Collections.Generic;

namespace testProject.Models {
    public class GroupViewModel {
        public Guid Id { get; set; }

        public string Аbbreviation { get; set; }

        public Guid CuratorId { get; set; }
        public CuratorViewModel Curator { get; set; }

        public ICollection<StudentViewModel> Students { get; set; }
    }
}
