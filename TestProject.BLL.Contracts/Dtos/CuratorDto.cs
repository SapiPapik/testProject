using System;
using System.Collections.Generic;

namespace TestProject.BLL.Contracts.Dtos {
    public class CuratorDto {
        public Guid Id { get; set; }

        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
    }
}
