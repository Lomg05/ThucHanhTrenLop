using Lab01.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab01.Controllers
{
    [Route("Admin/Student")]
    public class StudentController : Controller
    {
        private static List<Student> ListStudents = new List<Student>();

        public StudentController()
        {
            if (!ListStudents.Any())
            {
                ListStudents = new List<Student>()
                {
                    new Student() { Id = 101, Name = "Việt Anh", Branch = Branch.IT, Gender = Gender.Male, IsRegular = true, Address = "A1-2023", Email = "vanh@g.com", DateOfBirth = new DateTime(2000,5,10)},
                    new Student() { Id = 102, Name = "Minh Đức", Branch = Branch.BE, Gender = Gender.Female, IsRegular = true, Address = "A1-2019", Email = "duc@g.com", DateOfBirth = new DateTime(1999,4,15)},
                    new Student() { Id = 103, Name = "Tường Huy", Branch = Branch.CE, Gender = Gender.Male, IsRegular = false, Address = "A1-2020", Email = "huy@g.com", DateOfBirth = new DateTime(1998,3,20)},
                    new Student() { Id = 104, Name = "Thế Vũ", Branch = Branch.EE, Gender = Gender.Female, IsRegular = false, Address = "A1-2021", Email = "vu@g.com", DateOfBirth = new DateTime(1997,2,12)}
                };
            }
        }

        [HttpGet("List")]
        public IActionResult Index()
        {
            return View(ListStudents);
        }

        [HttpGet("Add")]
        public IActionResult Create()
        {
            LoadViewBags();
            return View();
        }

       
        [HttpPost("Add")]
        public IActionResult Create(Student s)
        {
            if (ModelState.IsValid)
            {
                s.Id = ListStudents.Last().Id + 1;
                ListStudents.Add(s);

                return RedirectToAction("Index");
            }

            // Lỗi validation -> nạp lại dữ liệu dropdown
            LoadViewBags();
            return View(s);
        }

    
        private void LoadViewBags()
        {
            ViewBag.AllGenders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();

            ViewBag.AllBranches = new List<SelectListItem>()
            {
                new SelectListItem { Text = "IT", Value = "1"},
                new SelectListItem { Text = "BE", Value = "2"},
                new SelectListItem { Text = "CE", Value = "3"},
                new SelectListItem { Text = "EE", Value = "4"},
            };
        }
    }
}
