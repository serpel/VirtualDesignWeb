using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VirtualDesign.Models
{
    public class Tag
    {
        [Key]
        public Int32 TagId { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(50, MinimumLength=1, ErrorMessage="Cannot be longer than {0} characters")]
        public String Name { get; set; }

        [Required(ErrorMessage="{0} is required")]
        [Display(Name = "Model")]
        public Int32 ModelId { get; set; }

        public virtual Model Model { get; set; }
       
    }
}