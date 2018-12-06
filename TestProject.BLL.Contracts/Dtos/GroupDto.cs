using System;
using System.Collections.Generic;

namespace TestProject.BLL.Contracts.Dtos {
    public class GroupDto {
        public Guid Id { get; set; }

        public string Аbbreviation { get; set; }

        public Guid CuratorId { get; set; }
        public CuratorDto Curator { get; set; }

        public IEnumerable<StudentDto> Students { get; set; }
    }
}
