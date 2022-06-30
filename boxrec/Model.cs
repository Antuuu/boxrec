using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace boxrec
{
    /// <summary>
    /// Class <c>BoxrecContext</c> create db context for our database
    /// </summary>
    public class BoxrecContext : DbContext
    {
        /// <summary>
        /// Class <c>DbSet<Boxer> Boxers</c> maps Boxers table to Class <c>Boxer</c> properties
        /// </summary>
        public DbSet<Boxer> Boxers { get; set; }

        /// <summary>
        /// Class <c>DbSet<Fight> Fights</c> maps Fights table to Class <c>Fight</c> properties
        /// </summary>
        public DbSet<Fight> Fights { get; set; }

        /// <summary>
        /// Class <c>DbSet<Division> Divisions</c> maps Divisions table to Class <c>Division</c> properties
        /// </summary>
        public DbSet<Division> Divisions { get; set; }

        /// <summary>
        /// Get MS SQL connection string
        /// </summary>
        public string ConnectionString = @"Data Source=localhost;Initial Catalog=boxrec;Integrated Security=True";
        /// <summary>
        /// Configure <c>BoxrecContext</c> connection string
        /// </summary>
        public BoxrecContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public BoxrecContext(DbContextOptions options) : base(options)
        {
        }

        public BoxrecContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer(this.ConnectionString);
            }
        }
    }

}





