using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using TestProject.BLL.Contracts;
using TestProject.BLL.DataModels;
using TestProject.Web.Models;

namespace TestProject.Web.Controllers.Api
{
    public class StudentsController : ApiController
    {
        private readonly IStudentService _studentService;
        private object List;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public IHttpActionResult GetAllStudents()
        {
            var students = _studentService.GetAll();
            if (students != null)
            {
                return Ok(Mapper.Map<List<StudentViewModel>>(students));
            }

            return NotFound();
        }

        public IHttpActionResult GetSrudent(int id)
        {
            var student = _studentService.GetById(id);
            if (student != null)
            {
                return Ok(Mapper.Map<StudentViewModel>(student));
            }

            return NotFound();
        }

        [HttpPost]
        public void CreateStudent([FromBody]StudentViewModel student)
        {
            _studentService.Create(Mapper.Map<StudentDataModel>(student));
        }

        [HttpPut]
        public void EditStudent(int id, [FromBody]StudentViewModel student)
        {
            _studentService.Update(Mapper.Map<StudentDataModel>(student));
        }

        [HttpDelete]
        public void DeleteStudent(int id)
        {
            _studentService.Remove(id);
        }
    }
}