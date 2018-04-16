using System;

namespace TestProject.Web.Models
{
    public class StudentViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }

        public DateTime Birthday { get; set; }

        public bool IsStependint { get; set; }

        public int GroupId { get; set; }
        public GroupViewModel Group { get; set; }
    }
}
