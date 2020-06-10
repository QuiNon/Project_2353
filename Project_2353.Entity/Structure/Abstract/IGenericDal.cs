using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;

namespace Project_2353.Entity.Structure.Abstract
{
    public interface IGenericDal<T> where T:class
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetBy(Expression<Func<T,bool>> predicate);
        IIncludableQueryable<T, TProp> Include<TProp>(Expression<Func<T, TProp>> expression);
        T Add(T entity);  
        void Delete(T entity);
        void Edit(T entity); 
        void Edit(List<T> entities); 
    }
}