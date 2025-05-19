using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Simulation.DAL.Models;

namespace Simulation.DAL.Contexts
{
     public class AppDbContext :DbContext
    {
        private readonly string _connectionstring = @"Server=localhost\SQLEXPRESS;Database=NftDB;Trusted_Connection=True;TrustServerCertificate=True;";

        public DbSet<CollectionModel> CollectionModels { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionstring);
            base.OnConfiguring(optionsBuilder);
        }

    }
}
