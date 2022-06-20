using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace boxrec
{
    public class BoxrecContext : DbContext
    {
        public DbSet<Boxer> Boxers { get; set; }

        public string ConnectionString { get; }

        public BoxrecContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(this.ConnectionString);
        }
    }

}





