using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BGC.School.Application.ViewModels;
using BGC.School.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BGC.School.Controllers
{
    public class HomeController : Controller
    {
        private readonly SchoolContext _context;

        public HomeController(SchoolContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "学生统计信息";

            var students = from p in _context.Students
                           group p by p.EnrollDate.Date
                           into stuGroups
                           select new StudentGroup
                           {
                               Count = stuGroups.Count(),
                               EnrollmentDate = stuGroups.Key
                           };

            var dtos = students.ToList();

            return View(dtos);
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
