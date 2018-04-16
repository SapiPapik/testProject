using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.BLL.DataModels;

namespace TestProject.BLL.Contracts
{
    public interface ICuratorService
    {
        IEnumerable<CuratorDataModel> GetAll();
        CuratorDataModel GetById(int id);
        void Create(CuratorDataModel group);
        void Update(CuratorDataModel group);
        void Remove(int id);
    }
}
