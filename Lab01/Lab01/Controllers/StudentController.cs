using Lab01.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace Lab01.Controllers
{
    [Route("Admin/Student")] // 👈 Add route prefix for all actions
    public class StudentController : Controller
    {
        [HttpGet("Add")] // 👈 Route: /Admin/Student/Add
        public IActionResult Create()
        {
            ViewBag.AllGenders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();
            ViewBag.AllBranches = new List<SelectListItem>()
            {
                new SelectListItem{ Text = "IT", Value = "1"},
                new SelectListItem{ Text = "BE", Value = "2"},
                new SelectListItem{ Text = "CE", Value = "3"},
                new SelectListItem{ Text = "EE", Value = "4"},
            };
            return View();
        }

        [HttpPost("Add")] // 👈 Route: POST /Admin/Student/Add
        public IActionResult Create(Student s)
        {
            s.Id = ListStudents.Last().Id + 1;
            ListStudents.Add(s);
            return RedirectToAction("Index"); // still works (maps to /Admin/Student/List)
        }

        private static List<Student> ListStudents = new List<Student>();

        public StudentController()
        {
            if (!ListStudents.Any())
            {
                ListStudents = new List<Student>()
                {
                    new Student() { Id = 101, Name = "Việt Anh", Branch = Branch.IT, Gender = Gender.Male, IsRegular = true, Address = "A1-2023", Email = "vanh@g.com" },
                    new Student() { Id = 102, Name = "Minh Đức", Branch = Branch.BE, Gender = Gender.Female, IsRegular = true, Address = "A1-2019", Email = "duc@g.com" },
                    new Student() { Id = 103, Name = "Tường Huy", Branch = Branch.CE, Gender = Gender.Male, IsRegular = false, Address = "A1-2020", Email = "huy@g.com" },
                    new Student() { Id = 104, Name = "Thế Vũ", Branch = Branch.EE, Gender = Gender.Female, IsRegular = false, Address = "A1-2021", Email = "vu@g.com" }
                };
            }
        }

        [HttpGet("List")] // 👈 Route: /Admin/Student/List
        public IActionResult Index()
        {
            return View(ListStudents);
        }
    }
}
