using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Linq.Expressions;
using RoRoWo.Blog.Domain.Specification;

namespace RoRoWo.Blog.Domain
{
    public interface IRepositoryEx<T, TPageData> : IRepository<T, TPageData>
        where T : class,new()
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
        TPageData Find<S>(int PageIndex, int PageSize, ISpecification<T> condition, Expression<Func<T, S>> orderByExpression, bool IsDESC);
        
        
    }
}
