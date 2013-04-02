using System.Web.Mvc;
using RoRoWo.Blog.Utility;
using RoRoWo.Blog.Domain.Entities;

namespace RoRoWo.Blog.Web.Areas.MWeb.Controllers
{
    public class FUpLoadController : Controller
    {
        //
        // GET: /MWeb/FUpLoad/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SavePic(int utype)
        {
            string result = "";
            if (this.IsPostFile())
            {
                result = SaveRemoteFileHelper.SaveRequestFiles("imgFile", utype);

            }
            else
            {
                result = "{\"error\":1,\"message\":\"没有传文件\"}";
            }

            return Content(result);
        }

        /// <summary>
        /// 判断是否有上传的文件
        /// </summary>
        /// <returns>是否有上传的文件</returns>
        public bool IsPostFile()
        {
            for (int i = 0; i < System.Web.HttpContext.Current.Request.Files.Count; i++)
            {
                if (System.Web.HttpContext.Current.Request.Files[i].FileName != "")
                {
                    return true;
                }
            }
            return false;
        }

    }
}
