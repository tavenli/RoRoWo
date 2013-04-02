using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoRoWo.Blog.Infrastructure
{
    public partial class RoRoWoDBEntities : Domain.IUnitOfWork
    {
        #region 工作单元方法

        /// <summary>
        /// Commit all changes made in  a container.
        /// </summary>
        ///<remarks>
        /// If entity have fixed properties and optimistic concurrency problem exists 
        /// exception is thrown
        ///</remarks>
        public int Commit()
        {
            return base.SaveChanges();
        }

        /// <summary>
        /// Commit all changes made in  a container.
        /// </summary>
        ///<remarks>
        /// If entity have fixed properties and optimistic concurrency problem exists 
        /// client changes are refereshed
        ///</remarks>
        public void CommitAndRefreshChanges()
        {

        }


        /// <summary>
        /// Rollback changes not stored in databse at 
        /// this moment. See references of UnitOfWork pattern
        /// </summary>
        public void RollbackChanges()
        {

        }

        #endregion
    }

}
