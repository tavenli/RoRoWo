using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using RoRoWo.Blog.IoC;
using RoRoWo.Blog.Services;
using RoRoWo.Blog.Domain.Entities;
using RoRoWo.Blog.Utility;

namespace RoRoWo.Blog.Web.Controllers
{
    public class AjaxController : Controller
    {
        private readonly IArticleServices _articleService;
        /// <summary>
        /// 为控制器添加构造函数，方便IoC自动装配
        /// </summary>
        /// <param name="articleService"></param>
        public AjaxController(IArticleServices articleService)
        {
            _articleService = articleService;

        }

        public ActionResult Index(string jsoncallback)
        {
            IEnumerable<BlogArticle> list;

            //IArticleServices target = IoCHelper.Resolve<IArticleServices>();
            //list = target.GetList();

            list = _articleService.GetList();

            if (string.IsNullOrEmpty(jsoncallback))
            {
                //return Json(list, "application/json", JsonRequestBehavior.AllowGet);
                //return Json(list, JsonRequestBehavior.AllowGet);
                return JavaScript(SerializeHelper.JsonSerialize(list));
            }
            else
            {
                //使用JSONP
                string json = SerializeHelper.JsonSerialize(list);//序列化后的
                return JavaScript(jsoncallback + "(" + json + ")");
            }
        }

        public ActionResult Test()
        {

            return View();
        }

    }
}
