using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;
using Project_2353.Core.Factory.ResultFactory;
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

        public ProcessResult Add(UserEntity entity)
        {
            
            if(string.IsNullOrEmpty(entity.UserName))
                return new FailAddResult("User name cannot use");
            
            if(string.IsNullOrEmpty(entity.Firstname))
                return new FailAddResult("First name cannot be empty");
            
            if(string.IsNullOrEmpty(entity.LastName))
                return new FailAddResult("Last name cannot be empty");
            
            if(string.IsNullOrEmpty(entity.Email))
                return new FailAddResult("Email cannot be empty");
             
            
            
            var alreadyExist = _entity.GetAll().Any(x => x.UserNameNormalized == entity.UserName.ToLower());
            if(alreadyExist)
                return new FailAddResult("Username cannot use");
                
            return _entity.Add(entity);
        }

        public ProcessResult Delete(UserEntity entity)
        {
            return _entity.Delete(entity);
        }

        public ProcessResult Edit(UserEntity entity)
        {
            return _entity.Edit(entity);
        }

        public ProcessResult Edit(List<UserEntity> entities)
        {
            return _entity.Edit(entities);
        }
    }
}