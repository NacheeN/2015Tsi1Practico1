using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Shared.Entities;

namespace DataAccessLayer
{
    public class EmployeeDBContext: DbContext
    {
        public virtual DbSet<Employee> Employee { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FullTimeEmployee>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("FULL_TIME_EMP");
         
            });

            modelBuilder.Entity<PartTimeEmployee>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("PART_TIME_EMP");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
