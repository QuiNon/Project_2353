using System;

namespace Project_2353.Entity.Abstract
{
    public interface IUnitOfWork:IDisposable
    {
        IUserDal User { get; }
    }
}