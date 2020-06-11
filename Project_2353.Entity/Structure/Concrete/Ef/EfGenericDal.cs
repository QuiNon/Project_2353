using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Project_2353.Core.Factory.ResultFactory;
using Project_2353.Entity.Abstract;
using Project_2353.Entity.Contexts;
using Project_2353.Entity.Structure.Abstract;

namespace Project_2353.Entity.Structure.Concrete.Ef
{
    public class EfGenericDal<T> : IGenericDal<T> where T : class
    {
        private readonly Project2353DefaultDbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public EfGenericDal(Project2353DefaultDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet;
        }

        public IQueryable<T> GetBy(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public IIncludableQueryable<T, TProp> Include<TProp>(Expression<Func<T, TProp>> expression)
        {
            return _dbSet.Include(expression);
        }

        public ProcessResult Add(T entity)
        {
            _dbSet.Add(entity);
            var returnModel = new SuccessAddResult();
            returnModel.returnObj = entity;
            return returnModel;
        }


        public ProcessResult Delete(T entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;

            var returnModel = new SuccessDeleteResult();
            return returnModel;
        }

        public ProcessResult Edit(T entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;

            var returnModel = new SuccessUpdateResult();
            return returnModel;
        }

        public ProcessResult Edit(List<T> entities)
        {
            foreach (var entity in entities)
            {
                var result = Edit(entity);
                if (!result.State)
                    return new FailDeleteResult();
            }

            var returnModel = new SuccessUpdateResult();
            return returnModel;
        }
    }
}