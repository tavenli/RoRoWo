﻿using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;

using RoRoWo.Blog.Domain;
using RoRoWo.Blog.Model;
using System.Linq.Expressions;
using RoRoWo.Blog.Domain.Specification;

namespace RoRoWo.Blog.Infrastructure.Repository
{
    public abstract class BaseRepository<T> : IRepository<T, PageData<T>> where T : class, new()
    {
        /// <summary>
        /// 公用的数据上下文
        /// </summary>
        public RoRoWoDBEntities context;

        public BaseRepository(IUnitOfWork _UnitOfWork)
        {
            context = _UnitOfWork as RoRoWoDBEntities;
            
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

            var query = IsDESC
                ?
                (context.CreateObjectSet<T>()).Where(condition.SatisfiedBy()).OrderByDescending(orderByExpression)
                :
                (context.CreateObjectSet<T>()).Where(condition.SatisfiedBy()).OrderBy(orderByExpression);

            PageData<T> pageData = new PageData<T>();
            pageData.TotalCount = query.Count();
            pageData.DataList = query.Skip((PageIndex - 1) * PageSize).Take(PageSize).ToList();

            return pageData;

        }


        /// <summary>
        /// 得到所有数据
        /// </summary>
        /// <returns></returns>
        public List<T> GetList()
        {

            return (context.CreateObjectSet<T>()).ToList<T>();

        }

        /// <summary>
        /// 根据条件表达式取得相关数据
        /// </summary>
        /// <param name="condition">Lambda表达式</param>
        /// <returns></returns>
        public List<T> GetList(ISpecification<T> condition)
        {

            var query = (context.CreateObjectSet<T>()).Where(condition.SatisfiedBy());

            return query.ToList();

        }

        /// <summary>
        /// 根据条件表达式取得指定条数的数据
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <param name="TopN">返回的数据条数</param>
        /// <param name="condition">Lambda表达式</param>
        /// <param name="orderByExpression">Lambda表达式</param>
        /// <param name="IsDESC"></param>
        /// <returns></returns>
        public List<T> GetListByTopN<S>(int TopN, ISpecification<T> condition, Expression<Func<T, S>> orderByExpression, bool IsDESC)
        {

            var query = IsDESC
                ?
                (context.CreateObjectSet<T>()).Where(condition.SatisfiedBy()).OrderByDescending(orderByExpression).Take(TopN)
                :
                (context.CreateObjectSet<T>()).Where(condition.SatisfiedBy()).OrderBy(orderByExpression).Take(TopN);

            return query.ToList();

        }

        /// <summary>
        /// 返回指定条件的数据
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public T GetByCondition(ISpecification<T> condition)
        {

            var query = (context.CreateObjectSet<T>()).Where(condition.SatisfiedBy()).FirstOrDefault();

            //this.LoadReference(query);
            return query;

        }



        /// <summary>
        /// 将实体数据保存到数据库中
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void NewSave(T model)
        {

            //.Net 3.5支持的方法
            //context.AddToBlogArticle(model);

            //.Net 4.0支持的方法
            (context.CreateObjectSet<T>()).AddObject(model);

        }

        /// <summary>
        /// 更新数据数据库中的一条数据  根据主键值
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Modify(T model)
        {


            //.Net 3.5支持的方法
            //EntityKey key = context.CreateEntityKey("BlogArticle", model);
            //object orgData;
            //if (context.TryGetObjectByKey(key, out orgData))
            //{
            //    context.ApplyPropertyChanges(key.EntitySetName, model);
            //    context.SaveChanges();
            //    return true;
            //}
            //return false;

            //.Net 4.0支持的方法
            System.Data.EntityKey key = context.CreateEntityKey((context.CreateObjectSet<T>()).EntitySet.Name, model);
            object orgData;
            if (context.TryGetObjectByKey(key, out orgData))
            {
                context.ApplyCurrentValues(key.EntitySetName, model);

            }

        }

        /// <summary>
        /// 从数据库中删除数据   仅用于同一上下文的集合对象有效
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Remove(T model)
        {
            if (model != null)
            {
                context.DeleteObject(model);
            }

        }

        /// <summary>
        /// 删除指定条件的数据 最多删除一条
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public void Remove(ISpecification<T> condition)
        {
            var query = (context.CreateObjectSet<T>()).Where(condition.SatisfiedBy()).FirstOrDefault();
            if (query != null)
            {
                context.DeleteObject(query);

            }

        }

        /// <summary>
        /// 删除指定条件的数据
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public void Removes(ISpecification<T> condition)
        {
            var query = (context.CreateObjectSet<T>()).Where(condition.SatisfiedBy());
            if (query != null)
            {
                context.DeleteObject(query);
            }

        }

        /// <summary>
        /// 提交数据变更
        /// </summary>
        /// <returns></returns>
        public int SaveChanges()
        {
            return context.SaveChanges();
        }
    }

}

