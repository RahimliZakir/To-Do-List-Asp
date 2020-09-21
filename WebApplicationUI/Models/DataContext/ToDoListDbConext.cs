using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationUI.Models.Entity;

namespace WebApplicationUI.Models.DataContext
{
    public class ToDoListDbConext : DbContext
    {

        //Dependency Injection
        public ToDoListDbConext(DbContextOptions options)
            :base(options)
        {
                
        }

        public DbSet<Todo> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Todo>().Property(e => e.CreatedUserId).HasDefaultValueSql("DATEADD(HOUR,4,getutcdate())");
        }
    }

   
}
