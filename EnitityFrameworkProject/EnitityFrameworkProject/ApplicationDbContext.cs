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
            /* [Note: * if the connection is not configured with DataBase,
                        It will Congigure automatically.
                      * "DbContextOptionsBuilder optionsBuilder" is used to configure "DbContext" ,
                        options are provieded here to configure "DbContext". ]
            */
            if (optionsBuilder.IsConfigured == false)
                optionsBuilder.UseSqlServer(_connectionString);


            /* [Note: After overide in this method we also call the base classe's method ,
                      base.OnCongiguring() will do rest of the work automatically.]
            */
            base.OnConfiguring(optionsBuilder);     
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }



        public DbSet<Student> CollegeStudents { get; set; }
    }
}
