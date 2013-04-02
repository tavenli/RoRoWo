using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Linq.Expressions;
using RoRoWo.Blog.Domain.Specification;

namespace RoRoWo.Blog.Domain
{
    public interface IRepository<T, TPageData> where T : class,new()
    {
        /// <summary>
        /// 数据分页的方法
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <param name="PageIndex">当前页码</param>
        /// <param name="PageSize">每页显示条数</param>
        /// <param name="condition">数据查询条件表达式</param>
        /// <param name="orderByExpression">排序的条件表达式</param>
        /// <param name="IsDESC">是否为倒序</param>
        /// <returns></returns>
        TPageData FindAll<S>(int PageIndex, int PageSize, ISpecification<T> condition, Expression<Func<T, S>> orderByExpression, bool IsDESC);

        /// <summary>
        /// 得到所有数据
        /// </summary>
        /// <returns></returns>
        List<T> GetList();

        /// <summary>
        /// 根据条件表达式取得相关数据
        /// </summary>
        /// <param name="condition">Lambda表达式</param>
        /// <returns></returns>
        List<T> GetList(ISpecification<T> condition);

        /// <summary>
        /// 根据条件表达式取得指定条数的数据
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <param name="TopN">返回的数据条数</param>
        /// <param name="condition">Lambda表达式</param>
        /// <param name="orderByExpression">Lambda表达式</param>
        /// <param name="IsDESC"></param>
        /// <returns></returns>
        List<T> GetListByTopN<S>(int TopN, ISpecification<T> condition, Expression<Func<T, S>> orderByExpression, bool IsDESC);

        /// <summary>
        /// 返回指定条件的数据   最多返回一条
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        T GetByCondition(ISpecification<T> condition);

        /// <summary>
        /// 将实体数据保存到数据库中
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        void NewSave(T model);

        /// <summary>
        /// 更新数据数据库中的一条数据  根据主键值
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        void Modify(T model);

        /// <summary>
        /// 从数据库中删除数据   仅用于同一上下文的集合对象有效
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        void Remove(T model);

        /// <summary>
        /// 删除指定条件的数据 最多删除一条
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        void Remove(ISpecification<T> condition);

        /// <summary>
        /// 删除指定条件的数据
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        void Removes(ISpecification<T> condition);

        /// <summary>
        /// 提交数据变更
        /// </summary>
        /// <returns></returns>
        int SaveChanges();

    }
}
