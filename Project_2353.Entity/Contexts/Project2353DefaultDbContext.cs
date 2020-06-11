using System;
using System.IO;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Project_2353.Entity.Entities;

namespace Project_2353.Entity.Contexts
{
    public class Project2353DefaultDbContext:DbContext
    {
        public static readonly string LogFileName = $"{Directory.GetCurrentDirectory()}\\Logs\\LogFile_{DateTime.Now:yyyyMMddHHmmssfff}.ros";
        public Project2353DefaultDbContext(DbContextOptions options):base(options)
        {
            
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
        
        public virtual DbSet<UserEntity> User { get; set; }
        
        
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