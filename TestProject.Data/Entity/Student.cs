using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject.Data.Entity.Base;

namespace TestProject.Data.Entity
{
    public class Student : BaseEntity
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }

        public DateTime Birthday { get; set; }

        public bool IsStependint { get; set; }

        public int GroupId { get; set; }
        public Group Group { get; set; }
    }
}
