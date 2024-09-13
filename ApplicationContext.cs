using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadImage
{
    public class ApplicationContext : DbContext
    {

        public DbSet<ImageRecord> ImageRecords => Set<ImageRecord>();


        public ApplicationContext() => Database.EnsureCreated();


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = loadIMG.db");
        }



    }
}
