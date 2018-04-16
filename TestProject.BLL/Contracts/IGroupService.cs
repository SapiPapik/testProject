using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.BLL.DataModels;

namespace TestProject.BLL.Contracts
{
    public interface IGroupService
    {
        IEnumerable<GroupDataModel> GetAll();
        GroupDataModel GetById(int id);
        void Create(GroupDataModel group);
        void Update(GroupDataModel group);
        void Remove(int id);
    }
}
