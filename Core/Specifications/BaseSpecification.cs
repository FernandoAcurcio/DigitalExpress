using System.Linq.Expressions;

namespace Core.Specifications
{
    // This class represents a generic specification that can be used to define criteria for querying entities.
    // It implements the ISpecification<T> interface.
    public class BaseSpecification<T> : ISpecification<T>
    {
        public Expression<Func<T, bool>> Criteria { get; }
        
        public BaseSpecification()
        {
        }

        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }


        // List to store include expressions that can be passed to the ListAsync method for eager loading related entities.
        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();

        // Protected method to add include expressions to the list.
        protected void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            // Add the provided include expression to the Includes list.
            Includes.Add(includeExpression);
        }
    }
}
