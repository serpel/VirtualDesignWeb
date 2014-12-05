using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace VirtualDesign.Models
{
    public class 
        VirtualContextInitializer: DropCreateDatabaseAlways<VirtualContext>
    {
        protected override void Seed(VirtualContext context)
        {

            //base.Seed(context);
            context.Models.Add(
                new Model()
                {
                    Name = "Chair",
                    Description = "Fantastic Chair",
                    IsActive = true,
                    CreatedDate = DateTime.Now,
                    Category = context.Categories.Add(
                                new Category()
                                {
                                    Name = "Furniture",
                                    IsActive = true,
                                    CreatedDate = DateTime.Now
                                }),
                   PictureFile = null
                });

            context.Tags.Add(
                   new Tag()
                   {
                       Name = "wood",
                       ModelId = context.Models.FirstOrDefault().ModelId
                   });

            context.SaveChanges();
        }
    }
}