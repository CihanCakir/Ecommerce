using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Core.Spesifications;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Reposittory.EF
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly StoreContext _context;
        public GenericRepository(StoreContext context)
        {
            _context = context;
        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> ListWithSpesifcation(ISpesification<T> spesification)
        {
            return await ApplySpecification(spesification).ToListAsync();
        }
        public async Task<T> GetEntityWithSpesification(ISpesification<T> spesification)
        {
            return await ApplySpecification(spesification).FirstOrDefaultAsync();
        }
        public async Task<int> CountAsync(ISpesification<T> spesification)
        {
            return await ApplySpecification(spesification).CountAsync();
        }
        private IQueryable<T> ApplySpecification(ISpesification<T> spesification)
        {
            return SpesificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), spesification);
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;

        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
    }
}