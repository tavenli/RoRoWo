using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.Objects;
using System.Linq.Expressions;
using RoRoWo.Blog.Domain;
using RoRoWo.Blog.Domain.Entities;
using RoRoWo.Blog.Domain.Specification;
using RoRoWo.Blog.Model;
using RoRoWo.Blog.Repository;

namespace RoRoWo.Blog.Infrastructure.Repository
{
    public class ArticleRepository : BaseRepository<BlogArticle>, IArticleRepository
    {

        public ArticleRepository(IUnitOfWork _context) : base(_context) { }

        /// <summary>
        /// 数据分页的方法 (基于基本条件之上返回的数据)
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <param name="PageIndex">当前页码</param>
        /// <param name="PageSize">每页显示条数</param>
        /// <param name="condition">数据查询条件表达式</param>
        /// <param name="orderByExpression">排序的条件表达式</param>
        /// <param name="IsDESC">是否为倒序</param>
        /// <returns></returns>
        public PageData<BlogArticle> Find<S>(int PageIndex, int PageSize, ISpecification<BlogArticle> condition, Expression<Func<BlogArticle, S>> orderByExpression, bool IsDESC)
        {
            //合并两个规约条件中的表达式
            ISpecification<BlogArticle> baseCondition = new DirectSpecification<BlogArticle>(x => x.State == 1);
            condition = new AndSpecification<BlogArticle>(condition, baseCondition);

            return this.FindAll<S>(PageIndex, PageSize, condition, orderByExpression, IsDESC);
        }

        /// <summary>
        /// 加载实体模型的相关表数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private BlogArticle LoadReference(BlogArticle model)
        {
            //if (model != null)
            //{
            //    model.BlogCategoryReference.Load();
            //    model.BlogComment.Load();
            //    model.BlogDigg.Load();

            //}
            return model;
        }
               
    }


}
