using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _1811063058_KhoaVuHongNgoc.Models;
using _1811063058_KhoaVuHongNgoc.ViewModels;

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
            var viewModel = new CourseViewModel
            {
                categories = _dbContext.categories.ToList()
            };
            return View(viewModel);
        }
    }
}