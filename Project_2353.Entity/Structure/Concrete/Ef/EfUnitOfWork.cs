using Project_2353.Core.Factory.ResultFactory;
using Project_2353.Entity.Abstract;
using Project_2353.Entity.Concrete.Ef;
using Project_2353.Entity.Contexts;
using Project_2353.Entity.Entities;
using Project_2353.Entity.Structure.Abstract;

namespace Project_2353.Entity.Structure.Concrete.Ef
{
    public class EfUnitOfWork:IUnitOfWork
    {
        
        private readonly Project2353DefaultDbContext _dbContext;

        public EfUnitOfWork(Project2353DefaultDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IProcessResult CreateResult()
        {
            return new _ProcessResult();
        }
        
        public void Dispose()
        {
            _dbContext.Dispose();
        }

        private IUserDal _user;
        public IUserDal User => _user ??= new EfUserDal(new EfGenericDal<UserEntity>(_dbContext));
      
        
        public int SaveChanges()
        { 
                var i = _dbContext.SaveChanges(); 
                return i;  
        }
    }
}