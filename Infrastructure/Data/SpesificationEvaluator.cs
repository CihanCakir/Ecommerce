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
            query = spesification.Includes.Aggregate(query, (current, include) => current.Include(include));
            return query;
        }
    }
}