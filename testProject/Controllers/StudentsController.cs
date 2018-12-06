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
    public class StudentsController : ApiController {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService) {
            _studentService = studentService ?? throw new ArgumentNullException(nameof(studentService));
        }

        [Route("students")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetAllStudents() {
            var students = await _studentService.GetAllAsync();
            return Request.CreateResponse(HttpStatusCode.OK, Mapper.Map<ICollection<StudentViewModel>>(students));
        }

        [Route("students/{studentId}")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetStudent(Guid studentId) {
            var student = await _studentService.GetByIdAsync(studentId);
            return Request.CreateResponse(HttpStatusCode.OK, Mapper.Map<StudentViewModel>(student));
        }

        [Route("students")]
        [HttpPost]
        public async Task<HttpResponseMessage> CreateStudent([FromBody]StudentViewModel student) {
            await _studentService.AddAsync(Mapper.Map<StudentDto>(student));
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [Route("students/{studentId}")]
        [HttpPut]
        public async Task<HttpResponseMessage> EditStudent(Guid studentId, [FromBody]StudentViewModel student) {
            await _studentService.UpdateAsync(studentId, Mapper.Map<StudentDto>(student));
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [Route("students/{studentId}")]
        [HttpDelete]
        public async Task<HttpResponseMessage> DeleteStudent(Guid studentId) {
            await _studentService.RemoveAsync(studentId);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}