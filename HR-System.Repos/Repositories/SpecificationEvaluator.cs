using HR_System.Core.Entities;
using HR_System.Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace HR_System.Repos.Repositories
{
    internal static class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecifications<TEntity> spec)
        {
            var query = inputQuery;    //_dbContext.Set<Employee>()


            if(spec.Criteria is not null)
                query = query.Where(spec.Criteria);    //_dbContext.Set<Employee>().Where(e => e.Salary > 10000)


            if(spec.OrderBy is not null)
                query = query.OrderBy(spec.OrderBy); //_dbContext.Set<Employee>().Where(e => e.Salary > 10000).OrderBy(e => e.FName)
            else if (spec.OrderByDesc is not null)
                query = query.OrderByDescending(spec.OrderByDesc); 
            //_dbContext.Set<Employee>().Where(e => e.Salary > 10000).OrderByDescending(e => e.Salary)


            if(spec.IsPaginationEnabled)
                query = query.Skip(spec.Skip).Take(spec.Take);
            //_dbContext.Set<Employee>().Where(e => e.Salary > 10000).OrderByDescending(e => e.Salary).Skip(0).Take(10)

            query = spec.Includes.Aggregate(query, (currentQuery, includeExpression) => currentQuery.Include(includeExpression));
            //_dbContext.Set<Employee>().Where(e => e.Salary > 10000).OrderByDescending(e => e.Salary)
            //                          .Skip(0).Take(10).Include(e => e.Department)

            


            return query;
        }
    }
}
