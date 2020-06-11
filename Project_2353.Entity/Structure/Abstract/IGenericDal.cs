using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;
using Project_2353.Core.Factory.ResultFactory;

namespace Project_2353.Entity.Structure.Abstract
{
    public interface IGenericDal<T> where T:class
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetBy(Expression<Func<T,bool>> predicate);
        IIncludableQueryable<T, TProp> Include<TProp>(Expression<Func<T, TProp>> expression);
        ProcessResult Add(T entity);  
        ProcessResult Delete(T entity);
        ProcessResult Edit(T entity); 
        ProcessResult Edit(List<T> entities); 
    }
}