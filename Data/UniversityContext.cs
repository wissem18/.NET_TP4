using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TP4.Models;

namespace TP4.Data
{
    public class UniversityContext:DbContext
    {
      

        public DbSet<Student> student { get; set; }
        private static UniversityContext context ;

        public static UniversityContext getContext()
        {
            if (context == null)
            {
                context = Instantiate_UniversityContext();
            }
            return context;
        }
        public UniversityContext(DbContextOptions o) : base(o) { }
        public static UniversityContext Instantiate_UniversityContext() { 
        
            var optionsBuilder= new DbContextOptionsBuilder<UniversityContext>();
            optionsBuilder.UseSqlite("Data Source = C:\\Users\\yousf\\source\\repos\\TP4\\DB\\2022 GL3 .NET Framework TP4 - SQLite database.db");
            Debug.WriteLine("Accepted");
            return new UniversityContext(optionsBuilder.Options);
        }
    }
}
