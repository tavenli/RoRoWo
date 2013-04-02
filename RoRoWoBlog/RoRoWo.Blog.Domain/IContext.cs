using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoRoWo.Blog.Domain
{
    public interface IContext : IUnitOfWork
    {
        /// <summary>
        /// Apply changes made in item or related items in your graph
        /// </summary>
        /// <typeparam name="TEntity">Type of item</typeparam>
        /// <param name="item">Item with changes</param>
        void SetChanges<TEntity>(TEntity item);

    }
}
