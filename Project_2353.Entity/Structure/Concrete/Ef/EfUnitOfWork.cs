﻿using Project_2353.Entity.Abstract;
using Project_2353.Entity.Concrete.Ef;
using Project_2353.Entity.Contexts;
using Project_2353.Entity.Entities;

namespace Project_2353.Entity.Structure.Concrete.Ef
{
    public class EfUnitOfWork:IUnitOfWork
    {
        
        private readonly Project2353DefaultDbContext _dbContext;

        public EfUnitOfWork(Project2353DefaultDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        private IUserDal _user;
        public IUserDal User => _user ??= new EfUserDal(new EfGenericDal<UserEntity>(_dbContext));
    }
}