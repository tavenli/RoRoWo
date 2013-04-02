using System.Collections.Generic;
using System.Web.Mvc;
using RoRoWo.Blog.Repository;
using RoRoWo.Blog.Services;
using RoRoWo.Blog.Domain.Entities;

namespace RoRoWo.Blog.Web.Controllers
{
    public class PartialViewController : Controller
    {
        private readonly ICategoryServices _categoryService;
        public PartialViewController(ICategoryServices categoryService) {
            _categoryService = categoryService;
        }

        //
        // GET: /PartialView/
        
        public ActionResult BlogHeader()
        {
            List<BlogCategory> cList = _categoryService.GetCateList();

            ViewData["cList"] = cList;

            return View();
        }

    }
}
