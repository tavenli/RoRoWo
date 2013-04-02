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

namespace RoRoWo.Blog.Repository
{
    public interface IArticleRepository : IRepository<BlogArticle, PageData<BlogArticle>>
    {
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
        PageData<BlogArticle> Find<S>(int PageIndex, int PageSize, ISpecification<BlogArticle> condition, Expression<Func<BlogArticle, S>> orderByExpression, bool IsDESC);
         

    }
}
