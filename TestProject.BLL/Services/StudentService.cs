using System.Collections.Generic;
using AutoMapper;
using TestPrject.DAL.Contract;
using TestProject.BLL.Contracts;
using TestProject.BLL.DataModels;
using TestProject.Data.Entity;

namespace TestProject.BLL.Services
{
    class StudentService : BaseService, IStudentService
    {
        public StudentService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public IEnumerable<StudentDataModel> GetAll()
        {
            var students = UnitOfWork.GetRepository<Student>().AllIncluding(s=> s.Group);
            return Mapper.Map<List<StudentDataModel>>(students);
        }

        public StudentDataModel GetById(int id)
        {
            var result = UnitOfWork.GetRepository<Student>().GetByIdIncluding(r=> r.Id == id, r=> r.Group);
            return result == null ? null : Mapper.Map<StudentDataModel>(result);
        }

        public void Create(StudentDataModel student)
        {
            UnitOfWork.GetRepository<Student>().Create(Mapper.Map<Student>(student));
            UnitOfWork.Commit();
        }

        public void Update(StudentDataModel student)
        {
            UnitOfWork.GetRepository<Student>().Update(Mapper.Map<Student>(student));
            UnitOfWork.Commit();
        }

        public void Remove(int id)
        {
            UnitOfWork.GetRepository<Student>().Remove(id);
            UnitOfWork.Commit();
        }
    }
}
