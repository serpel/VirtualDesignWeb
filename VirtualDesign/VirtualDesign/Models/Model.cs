using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VirtualDesign.Models
{
    public class Model
    {
        [Key]
        public Int32 ModelId { get; set; }

        [Required(ErrorMessage="{0} is required")]
        [StringLength(50, MinimumLength=1, ErrorMessage="Cannot be longer than {0} characters")]
        public String Name { get; set; }

        [StringLength(200, MinimumLength=1, ErrorMessage="Cannot be longer than {0} characters")]
        public string Description { get; set; }

        [Required(ErrorMessage="{0} is required")]
        [Display(Name = "Category")]
        public Int32 CategoryId {get; set;}

        [Display(Name = "Picture")]
        public byte[] PictureFile { get; set; }

        [Required(ErrorMessage="{0} is required")]
        [StringLength(50, MinimumLength=3, ErrorMessage="Cannot be longer than {0} characters")]
        [Display(Name = "User")]
        public String Username { get; set; }

        [Display(Name = "Is Active?")]
        public bool IsActive { get; set; }

        [Display(Name = "Created Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreatedDate { get; set; }

        //public virtual ApplicationUser User { get; set; }
        public virtual Category Category { get; set; }
        public virtual List<Tag> Tags {get; set;}

    }
}