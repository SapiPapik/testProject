using System.Collections.Generic;

namespace TestProject.Web.Models
{
    public class GroupViewModel
    {
        public int Id { get; set; }
        public string Аbbreviation { get; set; }

        public int CuratorId { get; set; }
        public CuratorViewModel Curator { get; set; }

        public IEnumerable<StudentViewModel> Students { get; set; }
    }
}
