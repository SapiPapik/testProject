using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using TestProject.BLL.Contracts;
using TestProject.BLL.DataModels;
using TestProject.Web.Models;

namespace TestProject.Web.Controllers.Api
{
    public class GroupsController : ApiController
    {
        private readonly IGroupService _groupService;

        public GroupsController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        public IHttpActionResult GetAllGroups()
        {
            var groups = _groupService.GetAll();
            if (groups != null)
            {
                var a = Mapper.Map<List<GroupViewModel>>(groups);
                return Ok(groups);
            }

            return NotFound();
        }

        public IHttpActionResult GetGroup(int id)
        {
            var group = _groupService.GetById(id);
            if (group != null)
            {
                return Ok(Mapper.Map<GroupViewModel>(group));
            }

            return NotFound();
        }

        [HttpPost]
        public void CreateGroup([FromBody]GroupViewModel group)
        {
            _groupService.Create(Mapper.Map<GroupDataModel>(group));
        }

        [HttpPut]
        public void EditGroup(int id, [FromBody]GroupViewModel group)
        {
            _groupService.Update(Mapper.Map<GroupDataModel>(group));
        }

        [HttpDelete]
        public void DeleteGroup(int id)
        {
            _groupService.Remove(id);
        }
    }
}