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
            if (string.IsNullOrWhiteSpace(entity.UserName))
                return new FailAddResult("User name cannot be empty");

            if (string.IsNullOrWhiteSpace(entity.Firstname))
                return new FailAddResult("First name cannot be empty");

            if (string.IsNullOrWhiteSpace(entity.LastName))
                return new FailAddResult("Last name cannot be empty");

            if (string.IsNullOrWhiteSpace(entity.Email))
                return new FailAddResult("Email cannot be empty");


            if (!(entity.UserName.Length >= 3 && entity.UserName.Length <= 100))
                return new FailAddResult("UserName Should be minimum 3 characters and a maximum of 100 characters ");
            if (!(entity.Email.Length >= 0 && entity.Email.Length <= 256))
                return new FailAddResult("Email Should be a maximum of 256 characters ");
            if (!(entity.Firstname.Length >= 3 && entity.Firstname.Length <= 50))
                return new FailAddResult("Firstname Should be minimum 3 characters and a maximum of 50 characters ");
            if (!(entity.LastName.Length >= 3 && entity.LastName.Length <= 50))
                return new FailAddResult("LastName Should be minimum 3 characters and a maximum of 50 characters ");


            var alreadyExist = _entity.GetAll().Any(x => x.UserNameNormalized == entity.UserName.ToLower());
            if (alreadyExist)
                return new FailAddResult("Username cannot use");

            entity.UserNameNormalized = entity.UserName.ToLower();
            return _entity.Add(entity);
        }

        public ProcessResult Delete(UserEntity entity)
        {
            return _entity.Delete(entity);
        }

        public ProcessResult Edit(UserEntity entity)
        {
            var currentEntity = GetAll().FirstOrDefault(x => x.Id == entity.Id);

            if (currentEntity == null)
                return new FailUpdateResult("Invalid User");

            if (string.IsNullOrWhiteSpace(entity.UserName))
                return new FailUpdateResult("User name cannot be empty");

            if (string.IsNullOrWhiteSpace(entity.Firstname))
                return new FailUpdateResult("First name cannot be empty");

            if (string.IsNullOrWhiteSpace(entity.LastName))
                return new FailUpdateResult("Last name cannot be empty");

            if (string.IsNullOrWhiteSpace(entity.Email))
                return new FailUpdateResult("Email cannot be empty");


            if (!(entity.UserName.Length >= 3 && entity.UserName.Length <= 100))
                return new FailUpdateResult("UserName Should be minimum 3 characters and a maximum of 100 characters ");
            if (!(entity.Email.Length >= 0 && entity.Email.Length <= 256))
                return new FailUpdateResult("Email Should be a maximum of 256 characters ");
            if (!(entity.Firstname.Length >= 3 && entity.Firstname.Length <= 50))
                return new FailUpdateResult("Firstname Should be minimum 3 characters and a maximum of 50 characters ");
            if (!(entity.LastName.Length >= 3 && entity.LastName.Length <= 50))
                return new FailUpdateResult("LastName Should be minimum 3 characters and a maximum of 50 characters ");


            var alreadyExist = _entity.GetAll().Any(x => x.Id != currentEntity.Id && x.UserNameNormalized == entity.UserName.ToLower());
            if (alreadyExist)
                return new FailUpdateResult("Username cannot use");

            currentEntity.Email = entity.Email;
            currentEntity.Firstname = entity.Firstname;
            currentEntity.LastName = entity.LastName;
            currentEntity.UserName = entity.UserName;
            currentEntity.UserNameNormalized = entity.UserName.ToLower();
            return _entity.Edit(currentEntity);
        }

        public ProcessResult Edit(List<UserEntity> entities)
        {
            return _entity.Edit(entities);
        }
    }
}