
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using _1811063058_KhoaVuHongNgoc.Models;

namespace _1811063058_KhoaVuHongNgoc.ViewModels
{
    public class CoursesViewModel
    {
        public IEnumerable<Course> UpcommingCourses { get; set; }
        public bool ShowAction { get; set; }

    }
}