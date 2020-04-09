using System.Linq;
using Core.Entities;
using Core.Spesifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class SpesificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpesification<TEntity> spesification)
        {
            var query = inputQuery;
            if (spesification.Criteria != null)
            {
                query = query.Where(spesification.Criteria); // p => p.ProductTypeId == id 
            }
            if (spesification.OrderBy != null)
            {
                query = query.OrderBy(spesification.OrderBy); // p => p.ProductTypeId == id 
            }
            if (spesification.OrderByDescending != null)
            {
                query = query.OrderByDescending(spesification.OrderByDescending); // p => p.ProductTypeId == id 
            }
            if (spesification.IsPagingEnabled)
            {
                query = query.Skip(spesification.Skip).Take(spesification.Take);
            }

            query = spesification.Includes.Aggregate(query, (current, include) => current.Include(include));
            return query;
        }
    }
}