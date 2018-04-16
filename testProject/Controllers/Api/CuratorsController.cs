using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using TestProject.BLL.Contracts;
using TestProject.BLL.DataModels;
using TestProject.Web.Models;

namespace TestProject.Web.Controllers.Api
{
    public class CuratorsController : ApiController
    {
        private readonly ICuratorService _curatorService;

        public CuratorsController(ICuratorService curatorService)
        {
            _curatorService = curatorService;
        }

        public IHttpActionResult GetAllCurators()
        {
            var curators = _curatorService.GetAll();
            if (curators != null) { 
                return Ok(Mapper.Map<List<CuratorViewModel>>(curators));
            }
            return NotFound();
        }

        public IHttpActionResult GetCurator(int id)
        {
            var curator = _curatorService.GetById(id);
            if (curator != null)
            {
                return Ok(Mapper.Map<CuratorViewModel>(curator));
            }
            return NotFound();
        }

        [HttpPost]
        public void CreateCurator([FromBody]CuratorViewModel curator)
        {
            _curatorService.Create(Mapper.Map<CuratorDataModel>(curator));
        }

        [HttpPut]
        public void EditCurator(int id, [FromBody]CuratorViewModel curator)
        {
            _curatorService.Update(Mapper.Map<CuratorDataModel>(curator));
        }

        [HttpDelete]
        public void DeleteCurator(int id)
        {
            _curatorService.Remove(id);
        }
    }
}
