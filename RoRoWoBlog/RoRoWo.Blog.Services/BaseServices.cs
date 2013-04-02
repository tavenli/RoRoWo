using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Linq.Expressions;
using RoRoWo.Blog.Domain;
using RoRoWo.Blog.Domain.Specification;
using RoRoWo.Blog.Model;

namespace RoRoWo.Blog.Services
{
    public abstract class BaseServices<T> : IBaseServices<T> where T : class,new()
    {
        protected IRepository<T, PageData<T>> repository = null;
        protected IUnitOfWork context = null;

        public BaseServices(IUnitOfWork _context, IRepository<T, PageData<T>> _Repository)
        {
            this.context = _context;
            this.repository = _Repository;
        }

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
        public PageData<T> FindAll<S>(int PageIndex, int PageSize, ISpecification<T> condition, Expression<Func<T, S>> orderByExpression, bool IsDESC)
        {
            return this.repository.FindAll<S>(PageIndex, PageSize, condition, orderByExpression, IsDESC);
        }

        /// <summary>
        /// 得到所有数据
        /// </summary>
        /// <returns></returns>
        public virtual List<T> GetList()
        {
            return this.repository.GetList();
        }

        /// <summary>
        /// 根据条件表达式取得相关数据
        /// </summary>
        /// <param name="condition">Lambda表达式</param>
        /// <returns></returns>
        public virtual List<T> GetList(ISpecification<T> condition)
        {
            return this.repository.GetList(condition);
        }
        
        /// <summary>
        /// 返回指定条件的数据   最多返回一条
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public virtual T GetByCondition(ISpecification<T> condition)
        {
            return this.repository.GetByCondition(condition);
            //return default(T);
        }

        /// <summary>
        /// 将实体数据保存到数据库中
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public virtual int NewSave(T model)
        {
            this.repository.NewSave(model);
            return this.context.Commit();
        }

        /// <summary>
        /// 更新数据数据库中的一条数据  根据主键值
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public virtual int Modify(T model)
        {
            this.repository.Modify(model);
            return this.context.Commit();
        }

        /// <summary>
        /// 从数据库中删除数据   仅用于同一上下文的集合对象有效
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public virtual int Remove(T model)
        {
            this.repository.Remove(model);
            return this.context.Commit();
        }

        /// <summary>
        /// 删除指定主键的数据
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public virtual int Remove(ISpecification<T> condition)
        {
            this.repository.Remove(condition);
            return this.context.Commit();
        }
    }
}
