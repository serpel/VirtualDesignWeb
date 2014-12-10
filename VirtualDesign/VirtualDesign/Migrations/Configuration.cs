namespace VirtualDesign.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using VirtualDesign.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<VirtualDesign.Models.VirtualContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(VirtualDesign.Models.VirtualContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Categories.AddOrUpdate(
                ca => ca.Name,
                new Category { Name = "Vehicles", IsActive = true, CreatedDate = DateTime.Now.AddDays(-12) },
                new Category { Name = "Food and Drinks", IsActive = true, CreatedDate =  DateTime.Now.AddDays(-20) },
                new Category { Name = "Building and Architecture", IsActive = true, CreatedDate = DateTime.Now },
                new Category { Name = "Furnishings", IsActive = true, CreatedDate = DateTime.Now.AddDays(30) },
                new Category { Name = "Products", IsActive = true, CreatedDate = DateTime.Now.AddDays(-3) },
                new Category { Name = "Electronics", IsActive = true, CreatedDate = DateTime.Now.AddDays(200) },
                new Category { Name = "Others", IsActive = true, CreatedDate = DateTime.Now.AddDays(-400) }
                );
            context.SaveChanges();

            context.Models.AddOrUpdate(
                mo => mo.Name,
                new Model { Name = "Big Table", Description = "this is a test for description", Username = "serpel", IsActive = true, CategoryId = context.Categories.FirstOrDefault().CatergoryId, CreatedDate = DateTime.Now, PictureFile = null  },
                new Model { Name = "Mesh Table", Description = "this is a test for description", Username = "susam", IsActive = true, CategoryId = context.Categories.FirstOrDefault().CatergoryId, CreatedDate = DateTime.Now.AddDays(-2), PictureFile = null },
                new Model { Name = "Random article", Description = "this is a test for description", Username = "nicky", IsActive = true, CategoryId = context.Categories.FirstOrDefault().CatergoryId, CreatedDate = DateTime.Now, PictureFile = null  },
                new Model { Name = "Chair", Description = "this is a test for description", Username = "choper", IsActive = true, CategoryId = context.Categories.FirstOrDefault().CatergoryId, CreatedDate = DateTime.Now.AddDays(-30), PictureFile = null  },
                new Model { Name = "Fancy Chair", Description = "this is a test for description", Username = "jairo", IsActive = true, CategoryId = context.Categories.FirstOrDefault().CatergoryId, CreatedDate = DateTime.Now.AddDays(-10), PictureFile = null  },
                new Model { Name = "Door in the garden", Description = "this is a test for description", Username = "artur", IsActive = true, CategoryId = context.Categories.FirstOrDefault().CatergoryId, CreatedDate = DateTime.Now.AddDays(-100), PictureFile = null  },
                new Model { Name = "Real design", Description = "this is a test for description", Username = "hulk", IsActive = true, CategoryId = context.Categories.FirstOrDefault().CatergoryId, CreatedDate = DateTime.MaxValue, PictureFile = null  }
                );

            context.SaveChanges();

            context.Tags.AddOrUpdate(
                t => t.Name,
                new Tag { Name = "new", ModelId = context.Models.FirstOrDefault().ModelId },
                new Tag { Name = "retro", ModelId = context.Models.FirstOrDefault().ModelId },
                new Tag { Name = "blue", ModelId = context.Models.FirstOrDefault().ModelId },
                new Tag { Name = "old", ModelId = context.Models.FirstOrDefault().ModelId }
                );

            context.SaveChanges();
        }
    }
}
