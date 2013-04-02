using System;
using System.Collections.Generic;
using System.Web.Mvc;
using RoRoWo.Blog.Domain.Entities;
using RoRoWo.Blog.Model;
using RoRoWo.Blog.Repository;
using RoRoWo.Blog.Services;
using RoRoWo.Blog.Utility;
using Webdiyer.WebControls.Mvc;
using RoRoWo.Blog.Domain.Specification;

namespace RoRoWo.Blog.Web.Areas.MWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryServices _categoryService;
        public CategoryController(ICategoryServices categoryService) {
            _categoryService = categoryService;
        }

        //
        // GET: /MWeb/Category/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Delete(int id)
        {
            ISpecification<BlogCategory> condition = new DirectSpecification<BlogCategory>(x => x.CateID == id);
            _categoryService.Remove(condition);

            ShowResultModel ShowMsg = new ShowResultModel();
            ShowMsg.PageTitle = string.Format("{0} 提示信息", "分类删除");
            ShowMsg.ReDirectUrl = Url.Action("List");
            ShowMsg.TipMsg = string.Format("分类ID为：{0} 删除成功", id);
            ShowMsg.Delay = 3000;

            ViewData["ShowMsg"] = ShowMsg;

            return View("ShowResult");
        }

        public ActionResult List(int? pageIndex, int? pageSize)
        {
            pageIndex = pageIndex ?? 1;
            pageSize = pageSize ?? 10;

            List<BlogCategory> aList = _categoryService.GetList();
            PagedList<BlogCategory> pList = new PagedList<BlogCategory>(aList, pageIndex.Value, pageSize.Value);
            ViewData["list"] = pList;

            return View();
        }


        public ActionResult New()
        {
            List<BlogCategory> cList = _categoryService.GetCateList();
            cList.Insert(0, new BlogCategory { CateID = 0, CateName = "顶级分类", State = 1, ParentID = 0 });
            SelectList CateList = new SelectList(cList, "CateID", "CateName");

            BlogCategory model = new BlogCategory();
            model.CreateTime = DateTime.Now;

            ViewData["model"] = model;
            ViewData["CateID"] = CateList;
            ViewData["hID"] = 0;

            return View("Edit");
        }


        public ActionResult Edit(int id)
        {
            BlogCategory model = _categoryService.GetByCondition(new DirectSpecification<BlogCategory>(x => x.CateID == id));

            List<BlogCategory> cList = _categoryService.GetCateList();
            cList.Insert(0, new BlogCategory { CateID = 0, CateName = "顶级分类", State = 1, ParentID = 0 });
            SelectList CateList = new SelectList(cList, "CateID", "CateName", model.ParentID);

            ViewData["model"] = model;
            ViewData["CateID"] = CateList;
            ViewData["hID"] = model.CateID;

            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Save(BlogCategory model, FormCollection form)
        {
            int hID = Convert.ToInt32(form["hID"]);
            int CateID = Convert.ToInt32(form["CateID"]);

            bool IsEdit = hID > 0;

            ShowResultModel ShowMsg = new ShowResultModel();


            if (IsEdit)
            {

                //编辑
                model = _categoryService.GetByCondition(new DirectSpecification<BlogCategory>(x => x.CateID == hID));

                model.CateName = RequestHelper.GetInputString(form["CateName"], "", true, true);
                model.ParentID = RequestHelper.GetInputInt32(form["CateID"], 0);
                model.State = RequestHelper.GetInputInt32(form["State"], 0);

                _categoryService.Modify(model);

                ShowMsg.PageTitle = string.Format("{0} 提示信息", "分类编辑");
                ShowMsg.ReDirectUrl = Url.Action("List");
                ShowMsg.TipMsg = string.Format("名称为：{0} 编辑成功", model.CateName);
                ShowMsg.Delay = 3000;


            }
            else
            {
                //新增

                model.CreateTime = DateTime.Now;

                ShowMsg.PageTitle = string.Format("{0} 提示信息", "新增分类");
                ShowMsg.ReDirectUrl = Url.Action("List");
                ShowMsg.TipMsg = string.Format("名称为：{0} 新增成功", model.CateName);
                ShowMsg.Delay = 3000;

                _categoryService.NewSave(model);

            }

            ViewData["ShowMsg"] = ShowMsg;
            return View("ShowResult");

        }


    }
}
