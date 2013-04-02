using System.Web.Mvc;
using RoRoWo.Blog.Utility;
using RoRoWo.Blog.Domain.Entities;

namespace RoRoWo.Blog.Web.Areas.MWeb.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /MWeb/Login/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string UserAccount, string UserPassWord, string ImgeCode)
        {
            
            return RedirectToAction("MainFrame", "Article");
        }

        public ActionResult VerifyImage()
        {
            ValidateCodeType s1 = new ValidateCode_Style3();
            string code = "6666";
            byte[] bytes = s1.CreateImage(out code);
            
            this.Session["MVerifyCode"] = code;

            return File(bytes, @"image/jpeg");
                        
        }

        

    }
}
