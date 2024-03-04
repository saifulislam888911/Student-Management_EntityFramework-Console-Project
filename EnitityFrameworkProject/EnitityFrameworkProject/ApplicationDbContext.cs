using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnitityFrameworkProject
{
    public class ApplicationDbContext : DbContext
    {
        private readonly string _connectionString;

        public DbSet<Student> CollegeStudents { get; set; }



        public ApplicationDbContext()
        {
            //_connectionString = "Server=HP-LAPTOP\\SQLEXPRESS;Database=Prac_CSharpB15;User Id=Practice_Project;Password=123456;Trust Server Certificate=True;";
            _connectionString = "Server=HP-LAPTOP\\SQLEXPRESS;" +
                "Database=Prac_CSharpB15;" +
                "User Id=Practice_Project;" +
                "Password=123456;" +
                "Trust Server Certificate=True;";
        }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
                optionsBuilder.UseSqlServer(_connectionString);

            base.OnConfiguring(optionsBuilder);     
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
