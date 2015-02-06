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
            context.Categories.AddOrUpdate(
                ca => ca.Name,
                new Category { Name = "Vehicles", IsActive = true, CreatedDate = DateTime.Now.AddDays(-12) },
                new Category { Name = "Food and Drinks", IsActive = true, CreatedDate = DateTime.Now.AddDays(-20) },
                new Category { Name = "Building and Architecture", IsActive = true, CreatedDate = DateTime.Now },
                new Category { Name = "Furnishings", IsActive = true, CreatedDate = DateTime.Now.AddDays(30) },
                new Category { Name = "Products", IsActive = true, CreatedDate = DateTime.Now.AddDays(-3) },
                new Category { Name = "Electronics", IsActive = true, CreatedDate = DateTime.Now.AddDays(200) },
                new Category { Name = "Others", IsActive = true, CreatedDate = DateTime.Now.AddDays(-400) }
                );
            context.SaveChanges();

            context.Models.AddOrUpdate(
                mo => mo.Name,
                new Model { Name = "Big Table", Description = "this is a test for description", Username = "serpel", IsActive = true, CategoryId = context.Categories.FirstOrDefault().CategoryId, CreatedDate = DateTime.Now.AddDays(-5), PictureFile = "https://lh6.googleusercontent.com/-55osAWw3x0Q/URquUtcFr5I/AAAAAAAAAbs/rWlj1RUKrYI/s1024/A%252520Photographer.jpg", ModelFile = "https://3dwarehouse.sketchup.com/warehouse/getpubliccontent?contentId=fc3ba696-f3a2-4749-a592-fbe29451d013&fn=Cadeira-Selva.skp", Likes = 0 },
                new Model { Name = "Mesh Table", Description = "this is a test for description", Username = "susam", IsActive = true, CategoryId = context.Categories.FirstOrDefault().CategoryId, CreatedDate = DateTime.Now.AddDays(-2), PictureFile = "https://lh6.googleusercontent.com/-55osAWw3x0Q/URquUtcFr5I/AAAAAAAAAbs/rWlj1RUKrYI/s1024/A%252520Photographer.jpg", ModelFile = "https://3dwarehouse.sketchup.com/warehouse/getpubliccontent?contentId=fc3ba696-f3a2-4749-a592-fbe29451d013&fn=Cadeira-Selva.skp", Likes = 0 },
                new Model { Name = "Random article", Description = "this is a test for description", Username = "nicky", IsActive = true, CategoryId = context.Categories.FirstOrDefault().CategoryId, CreatedDate = DateTime.Now, PictureFile = "https://lh6.googleusercontent.com/-55osAWw3x0Q/URquUtcFr5I/AAAAAAAAAbs/rWlj1RUKrYI/s1024/A%252520Photographer.jpg", ModelFile = "https://3dwarehouse.sketchup.com/warehouse/getpubliccontent?contentId=fc3ba696-f3a2-4749-a592-fbe29451d013&fn=Cadeira-Selva.skp", Likes = 0 },
                new Model { Name = "Chair", Description = "this is a test for description", Username = "choper", IsActive = true, CategoryId = context.Categories.FirstOrDefault().CategoryId, CreatedDate = DateTime.Now.AddDays(-30), PictureFile = "https://lh6.googleusercontent.com/-55osAWw3x0Q/URquUtcFr5I/AAAAAAAAAbs/rWlj1RUKrYI/s1024/A%252520Photographer.jpg", ModelFile = "https://3dwarehouse.sketchup.com/warehouse/getpubliccontent?contentId=fc3ba696-f3a2-4749-a592-fbe29451d013&fn=Cadeira-Selva.skp", Likes = 0 },
                new Model { Name = "Fancy Chair", Description = "this is a test for description", Username = "jairo", IsActive = true, CategoryId = context.Categories.FirstOrDefault().CategoryId, CreatedDate = DateTime.Now.AddDays(-10), PictureFile = "https://lh6.googleusercontent.com/-55osAWw3x0Q/URquUtcFr5I/AAAAAAAAAbs/rWlj1RUKrYI/s1024/A%252520Photographer.jpg", ModelFile = "https://3dwarehouse.sketchup.com/warehouse/getpubliccontent?contentId=fc3ba696-f3a2-4749-a592-fbe29451d013&fn=Cadeira-Selva.skp", Likes = 0 },
                new Model { Name = "Door in the garden", Description = "this is a test for description", Username = "artur", IsActive = true, CategoryId = context.Categories.FirstOrDefault().CategoryId, CreatedDate = DateTime.Now.AddDays(-100), PictureFile = "https://lh6.googleusercontent.com/-55osAWw3x0Q/URquUtcFr5I/AAAAAAAAAbs/rWlj1RUKrYI/s1024/A%252520Photographer.jpg", ModelFile = "https://3dwarehouse.sketchup.com/warehouse/getpubliccontent?contentId=fc3ba696-f3a2-4749-a592-fbe29451d013&fn=Cadeira-Selva.skp", Likes = 0 },
                new Model { Name = "Real design", Description = "this is a test for description", Username = "hulk", IsActive = true, CategoryId = context.Categories.FirstOrDefault().CategoryId, CreatedDate = DateTime.Now.AddDays(-10), PictureFile = "https://lh6.googleusercontent.com/-55osAWw3x0Q/URquUtcFr5I/AAAAAAAAAbs/rWlj1RUKrYI/s1024/A%252520Photographer.jpg", ModelFile = "https://3dwarehouse.sketchup.com/warehouse/getpubliccontent?contentId=fc3ba696-f3a2-4749-a592-fbe29451d013&fn=Cadeira-Selva.skp", Likes = 0 }
                );

            context.SaveChanges();

            /*context.Tags.AddOrUpdate(
                t => t.Name,
                new Tag { Name = "new", ModelId = context.Models.FirstOrDefault().ModelId },
                new Tag { Name = "retro", ModelId = context.Models.FirstOrDefault().ModelId },
                new Tag { Name = "blue", ModelId = context.Models.FirstOrDefault().ModelId },
                new Tag { Name = "old", ModelId = context.Models.FirstOrDefault().ModelId }
                );

            context.SaveChanges();*/
        }
    }
}
