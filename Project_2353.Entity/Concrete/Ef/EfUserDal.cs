using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;
using Project_2353.Entity.Abstract;
using Project_2353.Entity.Entities;
using Project_2353.Entity.Structure.Concrete.Ef;

namespace Project_2353.Entity.Concrete.Ef
{
    public class EfUserDal : IUserDal
    {
        private readonly EfGenericDal<UserEntity> _entity;

        public EfUserDal(EfGenericDal<UserEntity> entity)
        {
            this._entity = entity;
        }

        public IQueryable<UserEntity> GetAll()
        {
            return _entity.GetAll();
        }

        public IQueryable<UserEntity> GetBy(Expression<Func<UserEntity, bool>> predicate)
        {
            return _entity.GetBy(predicate);
        }

        public IIncludableQueryable<UserEntity, TProp> Include<TProp>(Expression<Func<UserEntity, TProp>> expression)
        {
            return _entity.Include(expression);
        }

        public UserEntity Add(UserEntity entity)
        {
            return _entity.Add(entity);
        }

        public void Delete(UserEntity entity)
        {
            _entity.Delete(entity);
        }

        public void Edit(UserEntity entity)
        {
            _entity.Edit(entity);
        }

        public void Edit(List<UserEntity> entities)
        {
            _entity.Edit(entities);
        }
    }
}