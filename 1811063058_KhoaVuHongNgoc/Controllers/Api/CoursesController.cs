using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using _1811063058_KhoaVuHongNgoc.Models;
using Microsoft.AspNet.Identity;

namespace _1811063058_KhoaVuHongNgoc.Controllers.Api
{
    public class CoursesController : ApiController
    {
        public ApplicationDbContext _dbContext { get; set; }
        public CoursesController()
        {
            _dbContext = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Cancel (int id)
        {
            var userId = User.Identity.GetUserId();
            var course = _dbContext.Courses.Single(c => c.Id == id && c.LecturerId == userId);
            if (course.IsCanceled)
                return NotFound();
            course.IsCanceled = true;
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}