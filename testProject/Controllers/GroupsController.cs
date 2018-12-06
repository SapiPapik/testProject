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
    public class GroupsController : ApiController {
        private readonly IGroupService _groupService;

        public GroupsController(IGroupService groupService) {
            _groupService = groupService ?? throw new ArgumentNullException(nameof(groupService));
        }

        [Route("groups")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetAllGroups() {
            var groups = await _groupService.GetAllAsync();
            return Request.CreateResponse(HttpStatusCode.OK, Mapper.Map<ICollection<GroupViewModel>>(groups));
        }

        [Route("groups/{groupId}")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetGroup(Guid groupId) {
            var group = await _groupService.GetByIdAsync(groupId);
            return Request.CreateResponse(HttpStatusCode.OK, Mapper.Map<GroupViewModel>(group));
        }

        [Route("groups/{groupId}")]
        [HttpPost]
        public async Task<HttpResponseMessage> AddUserToGroup(Guid groupId, [FromBody] StudentViewModel student) {
            await _groupService.AddStudentToGroup(groupId, Mapper.Map<StudentDto>(student));
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [Route("groups")]
        [HttpPost]
        public async Task<HttpResponseMessage> CreateGroup([FromBody]GroupViewModel group) {
            await _groupService.AddAsync(Mapper.Map<GroupDto>(group));
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [Route("groups/groupId")]
        [HttpPut]
        public async Task<HttpResponseMessage> EditGroup(Guid groupId, [FromBody]GroupViewModel group) {
            await _groupService.UpdateAsync(groupId, Mapper.Map<GroupDto>(group));
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [Route("groups/groupId")]
        [HttpPut]
        public async Task<HttpResponseMessage> DeleteUserFromGroup(Guid groupId, [FromBody]StudentViewModel student) {
            await _groupService.RemoveStudentFromGroup(groupId, student.Id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [Route("groups/groupId")]
        [HttpDelete]
        public async Task<HttpResponseMessage> DeleteGroup(Guid groupId) {
            await _groupService.RemoveAsync(groupId);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}