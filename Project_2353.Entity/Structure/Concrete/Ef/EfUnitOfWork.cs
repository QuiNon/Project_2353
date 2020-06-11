using System;
using System.IO;
using System.Text;
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
        public static readonly string LogFileName = $"{Directory.GetCurrentDirectory()}\\Logs\\LogFile_{DateTime.Now:yyyyMMddHHmmssfff}.ros";

        private readonly Project2353DefaultDbContext _dbContext;

        public EfUnitOfWork(Project2353DefaultDbContext dbContext)
        {
            _dbContext = dbContext;
            try
            {
                // Check if file already exists. If yes, delete it.     
                if (File.Exists(LogFileName)) return;
                // Create a new file     
                using (var fs = File.Create(LogFileName))
                {
                    // Add some text to file    
                    var title = new UTF8Encoding(true).GetBytes($"Log initializing:{DateTime.Now}\r\n");
                    fs.Write(title, 0, title.Length);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
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
            try
            {
                var i = _dbContext.SaveChanges(); 
                return i;
            }
            catch (Exception e)
            {
                SaveLog(e.Message);
                return -1;
            }
        }
        public static void SaveLog(string context)
        {
            try
            { 
                File.AppendAllText(LogFileName, context);
                File.AppendAllText(LogFileName, "\r\n"); 
            }
            catch (Exception e)
            {
                // ignored
            }
        }
    }
}