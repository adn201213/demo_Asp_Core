using demo.DAL.entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo.DAL.dataBase
{
    public class DemoContext : DbContext
    {
        public DemoContext(DbContextOptions<DemoContext> options):base( options){}
        public DbSet<Employee> employees { get; set; }


    }
}
