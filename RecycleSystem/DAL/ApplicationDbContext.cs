using RecycleSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RecycleSystem.DAL
{
    public class ApplicationDbContext : DbContext 
    {
        public DbSet<TypeModel> Types { get; set; }
    }
}