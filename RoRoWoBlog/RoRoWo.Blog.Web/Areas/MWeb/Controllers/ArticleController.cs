using System;
using System.Collections.Generic;
using System.Web.Mvc;
using RoRoWo.Blog.Model;
using RoRoWo.Blog.Repository;
using RoRoWo.Blog.Services;
using RoRoWo.Blog.Utility;
using Webdiyer.WebControls.Mvc;
using RoRoWo.Blog.Domain.Entities;
using RoRoWo.Blog.Domain.Specification;

namespace RoRoWo.Blog.Web.Areas.MWeb.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleServices _articleService;
        private readonly ICategoryServices _categoryService;
        public ArticleController(IArticleServices articleService, ICategoryServices categoryService) {
            _articleService = articleService;
            _categoryService = categoryService;
        }

        //
        // GET: /MWeb/Article/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MainFrame()
        {
            return View();
        }

        public ActionResult Welcome()
        {
            return View();
        }

        public ActionResult LogOut()
        {
            return View();
        }

        public ActionResult ArticleDelete(int id)
        {
            ISpecification<BlogArticle> condition = new DirectSpecification<BlogArticle>(x => x.ArticleID == id);
            _articleService.Remove(condition);

            ShowResultModel ShowMsg = new ShowResultModel();
            ShowMsg.PageTitle = string.Format("{0} 提示信息", "博文删除");
            ShowMsg.ReDirectUrl = Url.Action("ArticleList");
            ShowMsg.TipMsg = string.Format("博文ID为：{0} 删除成功", id);
            ShowMsg.Delay = 3000;

            ViewData["ShowMsg"] = ShowMsg;

            return View("ShowResult");
        }

        public ActionResult ArticleList(int? pageIndex, int? pageSize)
        {
            pageIndex = pageIndex ?? 1;
            pageSize = pageSize ?? 10;

            List<BlogCategory> cList = _categoryService.GetCateList();
            cList.Insert(0, new BlogCategory { CateID = 0, CateName = "全部分类", State = 1, ParentID = 0 });
            SelectList CateList = new SelectList(cList, "CateID", "CateName");

            ViewData["CateID"] = CateList;
            ISpecification<BlogArticle> condition = new DirectSpecification<BlogArticle>(x => x.ArticleID > 0);
            PageData<BlogArticle> aList = _articleService.FindAll<int>(pageIndex.Value, pageSize.Value, condition, x => x.ArticleID, true);
            PagedList<BlogArticle> pList = new PagedList<BlogArticle>(aList.DataList, pageIndex.Value, pageSize.Value, aList.TotalCount);
            ViewData["pList"] = pList;

            return View();
        }


        public ActionResult ArticleNew()
        {
            List<BlogCategory> cList = _categoryService.GetCateList();
            SelectList CateList = new SelectList(cList, "CateID", "CateName");

            BlogArticle model = new BlogArticle();
            model.CreateTime = DateTime.Now;
            model.UpdateTime = DateTime.Now;
            model.PublishTime = DateTime.Now;

            ViewData["model"] = model;
            ViewData["CateID"] = CateList;
            ViewData["hID"] = 0;

            return View("ArticleEdit");
        }


        public ActionResult ArticleEdit(int id)
        {
            ISpecification<BlogArticle> condition = new DirectSpecification<BlogArticle>(x => x.ArticleID == id);
            BlogArticle model = _articleService.GetByCondition(condition);

            List<BlogCategory> cList = _categoryService.GetCateList();
            SelectList CateList = new SelectList(cList, "CateID", "CateName", model.BlogCategory.CateID);

            ViewData["model"] = model;
            ViewData["CateID"] = CateList;
            ViewData["hID"] = model.ArticleID;

            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ArticleSave(BlogArticle model, FormCollection form)
        {
            int hID = Convert.ToInt32(form["hID"]);
            int CateID = Convert.ToInt32(form["CateID"]);

            bool DownMeta = Convert.ToBoolean(form["DownMeta"]);
            bool AutoMark = Convert.ToBoolean(form["AutoMark"]);
            bool TopAsThumbnail = Convert.ToBoolean(form["TopAsThumbnail"]);

            bool IsEdit = hID > 0;

            if (IsEdit)
            {
                //编辑                
                model = _articleService.GetByCondition(new DirectSpecification<BlogArticle>(x => x.ArticleID == hID));
                model.BlogCategory = _categoryService.GetByCondition(new DirectSpecification<BlogCategory>(x => x.CateID == CateID));
            }

            model.ImageUrl = RequestHelper.GetInputString(form["hImageUrl"], "", true, true);

            ShowResultModel ShowMsg = new ShowResultModel();

            model.Content = RequestHelper.GetInputString(form["Content"], "", false, false);

            //下载远程图片
            if (DownMeta)
            {
                ContentData cdata = SaveRemoteFileHelper.SavePic(model.Content, AutoMark);
                model.Content = cdata.Content;
                if (cdata.FileList.Count > 0 && TopAsThumbnail)
                {
                    model.ImageUrl = cdata.FileList[0];
                }
            }

            if (IsEdit)
            {
                //编辑

                model.Title = RequestHelper.GetInputString(form["Title"], "", true, true);
                model.IsTop = RequestHelper.GetInputBoolean(form["IsTop"].Split(',')[0], false);

                model.Tag = RequestHelper.GetInputString(form["Tag"], "", true, true);
                model.Description = RequestHelper.GetInputString(form["Description"], "", true, true);

                model.State = RequestHelper.GetInputInt32(form["State"], 0);
                model.PublishTime = RequestHelper.GetInputDateTime(form["PublishTime"], DateTime.Now);
                model.Hits = RequestHelper.GetInputInt32(form["Hits"], 0);

                _articleService.Modify(model);


                ShowMsg.PageTitle = string.Format("{0} 提示信息", "博文编辑");
                ShowMsg.ReDirectUrl = Url.Action("ArticleList");
                ShowMsg.TipMsg = string.Format("标题为：{0} 编辑成功", model.Title);
                ShowMsg.Delay = 3000;


            }
            else
            {
                //新增
                model.BlogCategory = _categoryService.GetByCondition(new DirectSpecification<BlogCategory>(x => x.CateID == CateID));

                model.CreateTime = DateTime.Now;
                model.UpdateTime = DateTime.Now;
                model.UserID = 0;
                model.UserName = "";
                model.UserIP = RequestHelper.GetIP();

                ShowMsg.PageTitle = string.Format("{0} 提示信息", "博文发布");
                ShowMsg.ReDirectUrl = Url.Action("ArticleList");
                ShowMsg.TipMsg = string.Format("标题为：{0} 发布成功", model.Title);
                ShowMsg.Delay = 3000;

                _articleService.NewSave(model);

            }

            ViewData["ShowMsg"] = ShowMsg;
            return View("ShowResult");

        }
    }
}
