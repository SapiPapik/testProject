using System.Collections.Generic;
using TestProject.Data.Entity.Base;

namespace TestProject.Data.Entity
{
    public class Curator : BaseEntity
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        
        public virtual IEnumerable<Group> Group { get; set; }
    }
}
