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

            context.Categories.AddOrUpdate(
                c => c.Name,
                new Category() { Name = "Vehicles", CreatedDate = DateTime.Now, IsActive = true },
                new Category() { Name = "Food And Drinks", CreatedDate = DateTime.Now, IsActive = true },
                new Category() { Name = "Building and Architecure", CreatedDate = DateTime.Now, IsActive = true },
                new Category() { Name = "Furnishings", CreatedDate = DateTime.Now, IsActive = true },
                new Category() { Name = "Products", CreatedDate = DateTime.Now, IsActive = true },
                new Category() { Name = "Electronics", CreatedDate = DateTime.Now, IsActive = true },
                new Category() { Name = "Others", CreatedDate = DateTime.Now, IsActive = true }
                );

            context.SaveChanges();

            context.Models.AddOrUpdate(
                 m => m.Name,
                 new Model()
                 {
                     Name = "Chair",
                     Description = "Fantastic Chair",
                     IsActive = true,
                     CreatedDate = DateTime.Now,
                     CategoryId = context.Categories.FirstOrDefault().CatergoryId,
                     PictureFile = null,
                     Username = "serpel"
                 });

            context.SaveChanges();

            context.Tags.AddOrUpdate(
                   t => t.Name,
                   new Tag(){ Name = "Wood", ModelId = context.Models.FirstOrDefault().ModelId },
                   new Tag(){ Name = "Modern", ModelId = context.Models.FirstOrDefault().ModelId },
                   new Tag(){ Name = "New", ModelId = context.Models.FirstOrDefault().ModelId } 
                   );

            context.SaveChanges();
        }
    }
}
