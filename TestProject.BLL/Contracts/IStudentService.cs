using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.BLL.DataModels;

namespace TestProject.BLL.Contracts
{
    public interface IStudentService
    {
        IEnumerable<StudentDataModel> GetAll();
        StudentDataModel GetById(int id);
        void Create(StudentDataModel group);
        void Update(StudentDataModel group);
        void Remove(int id);
    }
}
