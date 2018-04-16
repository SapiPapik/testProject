using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestProject.BLL.Contracts;

namespace TestProject.Web.Controllers
{
    public class WebGridController : Controller
    {
        private readonly IGroupService _groupService;
        private readonly IStudentService _studentService;
        private readonly ICuratorService _curatorService;

        public WebGridController(IGroupService groupService, IStudentService studentService, ICuratorService curatorService)
        {
            _groupService = groupService;
            _studentService = studentService;
            _curatorService = curatorService;
        }

        // GET: WebGrid
        public ActionResult Groups()
        {
            ViewBag.groups = _groupService.GetAll();
            return View();
        }

        public ActionResult Students()
        {
            ViewBag.students = _studentService.GetAll();
            return View();
        }

        public ActionResult Curators()
        {
            ViewBag.curators = _curatorService.GetAll();
            return View();
        }
    }
}