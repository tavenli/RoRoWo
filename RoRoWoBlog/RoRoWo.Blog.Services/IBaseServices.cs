using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Linq.Expressions;
using RoRoWo.Blog.Domain;
using RoRoWo.Blog.Model;
using RoRoWo.Blog.Domain.Specification;

namespace RoRoWo.Blog.Services
{
    public interface IBaseServices<T> where T : class,new()
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
        PageData<T> FindAll<S>(int PageIndex, int PageSize, ISpecification<T> condition, Expression<Func<T, S>> orderByExpression, bool IsDESC);

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
        int NewSave(T model);

        /// <summary>
        /// 更新数据数据库中的一条数据  根据主键值
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int Modify(T model);

        /// <summary>
        /// 从数据库中删除数据   仅用于同一上下文的集合对象有效
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int Remove(T model);

        /// <summary>
        /// 删除指定主键的数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int Remove(ISpecification<T> condition);

    }
}
