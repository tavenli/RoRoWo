using System.Collections.Generic;
using System.Web.Mvc;
using RoRoWo.Blog.Repository;
using RoRoWo.Blog.Services;
using RoRoWo.Blog.Utility;
using Webdiyer.WebControls.Mvc;
using RoRoWo.Blog.Domain.Entities;
using RoRoWo.Blog.Domain.Specification;
using RoRoWo.Blog.Common.Filters;


namespace RoRoWo.Blog.Web.Controllers
{
    public class BlogController : Controller
    {
        private readonly IArticleServices _articleService;
        /// <summary>
        /// 为控制器添加构造函数，方便IoC自动装配
        /// </summary>
        /// <param name="articleService"></param>
        public BlogController(IArticleServices articleService)
        {
            _articleService = articleService;
        }

        [LoggerFilter()]
        [ExceptionFilter()]
        public ActionResult Index(int? pageIndex, int? pageSize)
        {
            pageIndex = pageIndex ?? 1;
            pageSize = pageSize ?? 10;

            List<BlogArticle> aList = _articleService.GetList();
            PagedList<BlogArticle> pList = new PagedList<BlogArticle>(aList, pageIndex.Value, pageSize.Value);
            ViewData["pList"] = pList;

            return View();
        }

        public ActionResult PostView(int id)
        {
            ISpecification<BlogArticle> condition = new DirectSpecification<BlogArticle>(x => x.ArticleID == id);

            BlogArticle model = _articleService.GetByCondition(condition);
            ViewData["model"] = model;
            return View();
        }

        public ActionResult ToAdmin()
        {

            return RedirectToRoute("MWeb_default", new { controller = "Login" });
        }

        public ActionResult VerifyImage()
        {
            ValidateCodeType s1 = new ValidateCode_Style1();
            string code = "3333";
            byte[] bytes = s1.CreateImage(out code);

            this.Session["VerifyCode"] = code;

            return File(bytes, @"image/jpeg");

        }
    }
}
