using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _1811063058_KhoaVuHongNgoc.Models;
using _1811063058_KhoaVuHongNgoc.ViewModels;
using Microsoft.AspNet.Identity;

namespace _1811063058_KhoaVuHongNgoc.Controllers
{
    public class CouresController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public CouresController()
        {
            _dbContext = new ApplicationDbContext();
        }
        // GET: Coures
        public ActionResult Create()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult Create(CourseViewModel viewModel)
        {
            var course = new Course
            {
                LecturerId = User.Identity.GetUserId(),
                DateTime = viewModel.GetDateTime(),
                CategoryId = viewModel.Category,
                Place = viewModel.Place
            };
            _dbContext.Courses.Add(course);
            _dbContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}