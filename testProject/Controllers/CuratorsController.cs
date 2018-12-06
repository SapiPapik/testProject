using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using testProject.Filters;
using testProject.Models;
using TestProject.BLL.Contracts.Contracts;
using TestProject.BLL.Contracts.Dtos;

namespace testProject.Controllers {
    [ApiExceptionFilter]
    [RoutePrefix("api")]
    public class CuratorsController : ApiController {
        private readonly ICuratorService _curatorService;

        public CuratorsController(ICuratorService curatorService) {
            _curatorService = curatorService ?? throw new ArgumentNullException(nameof(curatorService));
        }

        [Route("curators")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetAllCurators() {
            var curators = await _curatorService.GetAllAsync();
            return Request.CreateResponse(HttpStatusCode.OK, Mapper.Map<ICollection<CuratorViewModel>>(curators));
        }

        [Route("curators/{curatorId}")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetCurator(Guid curatorId) {
            var curator = await _curatorService.GetByIdAsync(curatorId);
            return Request.CreateResponse(HttpStatusCode.OK, Mapper.Map<CuratorViewModel>(curator));
        }

        [Route("curators/{curatorId}/groups/{groupId}")]
        [HttpPut]
        public async Task<HttpResponseMessage> AddCuratorForGroup(Guid curatorId, Guid groupId) {
            await _curatorService.AddCuratorToGroup(curatorId, groupId);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [Route("curators")]
        [HttpPost]
        public async Task<HttpResponseMessage> CreateCurator([FromBody]CuratorViewModel curator) {
            await _curatorService.AddAsync(Mapper.Map<CuratorDto>(curator));
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [Route("curators/{curatorId}")]
        [HttpPut]
        public async Task<HttpResponseMessage> EditCurator(Guid curatorId, [FromBody]CuratorViewModel curator) {
            await _curatorService.UpdateAsync(curatorId, Mapper.Map<CuratorDto>(curator));
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [Route("curators/{curatorId}/groups/{groupId}")]
        [HttpDelete]
        public async Task<HttpResponseMessage> DeleteCurator(Guid curatorId, Guid groupId) {
            await _curatorService.RemoveCuratorFromGroup(curatorId, groupId);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [Route("curators/{curatorId}")]
        [HttpDelete]
        public async Task<HttpResponseMessage> DeleteCurator(Guid curatorId) {
            await _curatorService.RemoveAsync(curatorId);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
