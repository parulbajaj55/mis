using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Student.Management.System.Domain.Entities;

namespace Student.Management.System.Infrastructure.Data
{
    public class DataContext : DbContext
    {
         public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }  

        public DbSet<Stud> Students => Set<Stud>();
        public DbSet<Subject> Subjects => Set<Subject>();
    }
}