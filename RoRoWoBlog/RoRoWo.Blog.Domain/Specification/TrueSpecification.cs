
using System;
using System.Linq.Expressions;

namespace RoRoWo.Blog.Domain.Specification
{
    /// <summary>
    /// True specification
    /// </summary>
    /// <typeparam name="TEntity">Type of entity in this specification</typeparam>
    public class TrueSpecification<TEntity>
        :Specification<TEntity>
        where TEntity:class,new()
    {
        #region Specification overrides

        /// <summary>
        /// <see cref=" Microsoft.Samples.NLayerApp.Domain.Core.Specification.Specification{TEntity}"/>
        /// </summary>
        /// <returns><see cref=" Microsoft.Samples.NLayerApp.Domain.Core.Specification.Specification{TEntity}"/></returns>
        public override System.Linq.Expressions.Expression<Func<TEntity, bool>> SatisfiedBy()
        {
            Expression<Func<TEntity, bool>> trueExpression = t => true;
            return trueExpression;
        }

        //(CDLTLL)
        public override string SpecificationInstanceCode
        {
            get
            {
                return "TrueSpec-" + 
                       "-" + this.SatisfiedBy();
            }
        }
        #endregion
    }
}
