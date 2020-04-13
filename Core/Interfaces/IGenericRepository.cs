using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Spesifications;

namespace Core.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> GetEntityWithSpesification(ISpesification<T> spesification);
        Task<IReadOnlyList<T>> ListWithSpesifcation(ISpesification<T> spesification);
        Task<int> CountAsync(ISpesification<T> spesification);
        // TASK CREATE_ UPDATE_ DELETE METHODLARI EKLENECEK

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);



    }
}