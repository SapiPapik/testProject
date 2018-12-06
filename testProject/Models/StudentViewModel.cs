using System;

namespace testProject.Models {
    public class StudentViewModel {
        public Guid Id { get; set; }

        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public DateTime Birthday { get; set; }
        public bool IsStependint { get; set; }

        public Guid GroupId { get; set; }
    }
}
