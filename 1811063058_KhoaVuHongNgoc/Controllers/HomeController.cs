using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using _1811063058_KhoaVuHongNgoc.Models;
using _1811063058_KhoaVuHongNgoc.ViewModels;
using Microsoft.AspNet.Identity;

namespace _1811063058_KhoaVuHongNgoc.Controllers
{
    public class HomeController : Controller
    {
        public ApplicationDbContext _dbContext;
        public HomeController()
        {
            _dbContext = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var user = User.Identity.GetUserId();
            var upcommingCourses = _dbContext.Courses
                .Include(c => c.Lecturer)
                .Include(c => c.Category)
                .Where(c => c.DateTime > DateTime.Now);

            var viewModel = new CourseViewModel
            {
                UpcommingCourses = upcommingCourses,
                Followings = _dbContext.Followings.Where(a => a.FolloweeId == user).ToList(),
                Attendances = _dbContext.Attendances.Where(a => a.AttendeeId == user).ToList(),
                ShowAction = User.Identity.IsAuthenticated
            };
            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}