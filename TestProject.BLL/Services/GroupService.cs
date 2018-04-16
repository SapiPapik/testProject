using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using TestPrject.DAL.Contract;
using TestProject.BLL.Contracts;
using TestProject.BLL.DataModels;
using TestProject.Data.Entity;

namespace TestProject.BLL.Services
{
    public class GroupService : BaseService, IGroupService
    {
        public GroupService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public IEnumerable<GroupDataModel> GetAll()
        {
            var groups = UnitOfWork.GetRepository<Group>().AllIncluding(g=> g.Curator, g=> g.Students).ToList();
            return Mapper.Map<List<GroupDataModel>>(groups);
        }

        public GroupDataModel GetById(int id)
        {
            var result = UnitOfWork.GetRepository<Group>()
                .GetByIdIncluding(r => r.Id == id, r => r.Curator, r => r.Students);
            return result == null ? null : Mapper.Map<GroupDataModel>(result);
        }

        public void Create(GroupDataModel group)
        {
            UnitOfWork.GetRepository<Group>().Create(Mapper.Map<Group>(group));
            UnitOfWork.Commit();
        }

        public void Update(GroupDataModel group)
        {
            UnitOfWork.GetRepository<Group>().Update(Mapper.Map<Group>(group));
            UnitOfWork.Commit();
        }

        public void Remove(int id)
        {
            UnitOfWork.GetRepository<Group>().Remove(id);
            UnitOfWork.Commit();
        }
    }
}
