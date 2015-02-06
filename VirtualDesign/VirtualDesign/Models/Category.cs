using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace VirtualDesign.Models
{
    public class Category
    {
        [Key]
        public Int32 CategoryId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Cannot be longer than {0} characters")]
        public String Name { get; set; }

        [Display(Name = "Is Active?")]
        public bool IsActive { get; set; }

        [Display(Name = "Created Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreatedDate { get; set; }

        public virtual List<Model> Models { get; set; }
    }
}
