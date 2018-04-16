using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.BLL.DataModels
{
    public class GroupDataModel
    {
        public int Id { get; set; }
        public string Аbbreviation { get; set; }

        public int CuratorId { get; set; }
        public CuratorDataModel Curator { get; set; }

        public IEnumerable<StudentDataModel> Students { get; set; }
    }
}
