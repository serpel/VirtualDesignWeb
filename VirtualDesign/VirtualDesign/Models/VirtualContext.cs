using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace VirtualDesign.Models
{
    public class VirtualContext: DbContext
    {
        public VirtualContext() : base("DefaultConnection") { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}