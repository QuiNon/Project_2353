using System;
using Project_2353.Core.Factory.ResultFactory;
using Project_2353.Entity.Abstract;

namespace Project_2353.Entity.Structure.Abstract
{
    public interface IUnitOfWork:IDisposable
    {
        IProcessResult CreateResult();
        IUserDal User { get; }
        
        int SaveChanges();
    }
}