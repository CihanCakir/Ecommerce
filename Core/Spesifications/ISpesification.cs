using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.Spesifications
{
    public interface ISpesification<T>
    {

        Expression<Func<T, bool>> Criteria { get; } // Where Sorguları için
        List<Expression<Func<T, object>>> Includes { get; } // Eager Loading includes sorguları için yad then ıncludes
        Expression<Func<T, Object>> OrderBy { get; } // Sıralamalarda Kullanmak için 
        Expression<Func<T, Object>> OrderByDescending { get; } // Sıralamalarda Kullanmak için Azalanlariçin

        int Take { get; }
        int Skip { get; }
        bool IsPagingEnabled { get; }


    }
}