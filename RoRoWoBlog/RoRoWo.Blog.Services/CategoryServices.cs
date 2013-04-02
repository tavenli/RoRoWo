using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Linq.Expressions;
using RoRoWo.Blog.Repository;
using RoRoWo.Blog.Domain;
using RoRoWo.Blog.Domain.Entities;
using RoRoWo.Blog.Model;
using RoRoWo.Blog.Model.Enum;

namespace RoRoWo.Blog.Services
{
    public class CategoryServices : BaseServices<BlogCategory>, ICategoryServices
    {
        public CategoryServices(IUnitOfWork _context, ICategoryRepository _Repository)
            : base(_context, _Repository)
        {

        }

        public List<BlogCategory> GetCateList()
        {            
            return base.repository.GetList();

        }

        #region 加载Tree

        /// <summary>
        /// 传入一个树的根节点 得到整个树   (只查一次数据库)
        /// </summary>
        /// <param name="_Root">根节点</param>
        /// <returns></returns>
        public List<BlogCategory> GetCateTreeList(int _RootID)
        {
            //先加载所有数据
            List<BlogCategory> dtos = this.GetCateList();
            
            List<BlogCategory> _dtos = new List<BlogCategory>();

            this.BuildTree(dtos, _dtos, _RootID, 0);

            _dtos.Insert(0, new BlogCategory { CateID = 0, CateName = "顶级分类", State = 1, ParentID = 0 });
            return _dtos;

        }

        /// <summary>
        /// 得到一个分类树的递归方法
        /// </summary>
        /// <param name="dtos">源数据</param>
        /// <param name="_dtos">复制的数据</param>
        /// <param name="_Parent">父节点</param>
        /// <param name="_Deep">当前深度</param>
        /// <returns></returns>
        public List<BlogCategory> BuildTree(List<BlogCategory> dtos, List<BlogCategory> _dtos, int _ParentID, int _Deep)
        {

            string DeepStr = this.GetDeepStr(_Deep);

            for (int i = 0; i < dtos.Count; i++)
            {
                if (dtos[i].ParentID == _ParentID)
                {
                    
                    //加上树的符号
                    dtos[i].CateName = DeepStr + dtos[i].CateName;
                    //再插入
                    _dtos.Add(dtos[i]);

                    BuildTree(dtos, _dtos, dtos[i].CateID, (_Deep + 1));
                }
            }

            return _dtos;

        }

        /// <summary>
        /// 构造分类树的符号
        /// </summary>
        /// <param name="_Deep">树的深度</param>
        /// <returns></returns>
        private string GetDeepStr(int _Deep)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < _Deep; i++)
            {
                result.Append("　");
            }
            if (_Deep != 0)
            {
                result.Append("├");
            }

            return result.ToString();
        }

        #endregion

    }
}
