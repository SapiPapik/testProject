using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.BLL.DataModels
{
    public class StudentDataModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }

        public DateTime Birthday { get; set; }

        public bool IsStependint { get; set; }

        public int GroupId { get; set; }
        public GroupDataModel Group { get; set; }
    }
}
