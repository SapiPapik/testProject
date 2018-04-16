using System;
using System.Collections.Generic;
using AutoMapper;
using TestPrject.DAL.Contract;
using TestProject.BLL.Contracts;
using TestProject.BLL.DataModels;
using TestProject.Data.Entity;

namespace TestProject.BLL.Services
{
    public class CuratorService : BaseService, ICuratorService
    {

        public CuratorService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public IEnumerable<CuratorDataModel> GetAll()
        {
            var curators = UnitOfWork.GetRepository<Curator>().All();
            return Mapper.Map<List<CuratorDataModel>>(curators);
        }

        public CuratorDataModel GetById(int id)
        {
            var result = UnitOfWork.GetRepository<Curator>().GetById(id);
            return result == null ? null : Mapper.Map<CuratorDataModel>(result);
        }

        public void Create(CuratorDataModel curator)
        {
            UnitOfWork.GetRepository<Curator>().Create(Mapper.Map<Curator>(curator));
            UnitOfWork.Commit();
        }

        public void Update(CuratorDataModel curator)
        {
            UnitOfWork.GetRepository<Curator>().Update(Mapper.Map<Curator>(curator));
            UnitOfWork.Commit();
        }

        public void Remove(int id)
        {
            UnitOfWork.GetRepository<Curator>().Remove(id);
            UnitOfWork.Commit();
        }
    }
}
