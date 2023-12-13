using Core.Entities;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    // This static class, SpecificationEvaluator, is responsible for evaluating specifications on IQueryable<TEntity>.
    // It provides a method, GetQuery, to apply criteria and includes defined in a given ISpecification<TEntity> to an input query.
    // TEntity is constrained to be a type derived from BaseEntity.

    public static class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        // This method takes an input query and an ISpecification<TEntity>, applies the criteria and includes,
        // and returns the modified query.
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> spec)
        {
            // Initialize the query with the input query.
            var query = inputQuery;

            // Check if the specification has criteria defined.
            if (spec.Criteria != null)
            {
                // Apply the criteria to the query using the Where method.
                query = query.Where(spec.Criteria); // p => p.ProductTypeId == id
            }

            // Aggregate includes, if any, using LINQ's Aggregate method to apply them to the query.
            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));

            // Return the modified query with applied criteria and includes.
            return query;
        }
    }
}
