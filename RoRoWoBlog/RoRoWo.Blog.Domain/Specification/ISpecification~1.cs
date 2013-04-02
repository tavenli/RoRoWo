
using System;
using System.Linq.Expressions;

namespace RoRoWo.Blog.Domain.Specification
{
    //(CDLTLL)
    /// <summary>
    /// Base contract for Specification pattern, for more information
    /// about this pattern see http://martinfowler.com/apsupp/spec.pdf
    /// or http://en.wikipedia.org/wiki/Specification_pattern.
    /// This is really a variant implementation where we have added Linq and
    /// lambda expression into this pattern.
    /// </summary>
    /// <typeparam name="TEntity">Type of entity</typeparam>
    public interface ISpecification<TEntity>
        where TEntity : class,new()
    {
        /// <summary>
        /// Check if this specification is satisfied by a 
        /// specific expression lambda
        /// </summary>
        /// <returns></returns>
        Expression<Func<TEntity, bool>> SatisfiedBy();

        /// <summary>
        /// This Code/ID is used for IDs needed for storing query results within Cache
        /// </summary>
        string SpecificationInstanceCode { get; }
    }
}
