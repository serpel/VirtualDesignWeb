using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace VirtualDesign.Models
{

    [JsonObject(MemberSerialization.OptIn)]
    public class Model
    {
        [Key]
        [JsonProperty]
        public Int32 ModelId { get; set; }

        [JsonProperty]
        [Required(ErrorMessage="{0} is required")]
        [StringLength(50, MinimumLength=1, ErrorMessage="Cannot be longer than {1} characters")]
        public String Name { get; set; }

        [JsonProperty]
        [StringLength(200, MinimumLength=1, ErrorMessage="Cannot be longer than {1} characters")]
        public string Description { get; set; }

        [JsonProperty]
        [Required(ErrorMessage="{0} is required")]
        [Display(Name = "Category")]
        public Int32 CategoryId { get; set; }

        [JsonProperty]
        [Display(Name = "Picture")]
        public String PictureFile { get; set; }

        [JsonProperty]
        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "Model")]
        public String ModelFile { get; set; }

        [JsonProperty]
        [Required(ErrorMessage="{0} is required")]
        [StringLength(50, MinimumLength=3, ErrorMessage="Cannot be longer than {1} characters")]
        public String Username { get; set; }

        [JsonIgnore]
        [Display(Name = "Is Active?")]
        public bool IsActive { get; set; }

        [JsonIgnore]
        [Display(Name = "Created Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreatedDate { get; set; }

        [JsonProperty]
        [Display(Name = "Likes")]
        public int Likes { get; set; }

        [JsonProperty]
        [Display(Name = "Tags")]
        [StringLength(200, MinimumLength = 1, ErrorMessage = "Cannot be longer than {1} characters")]
        public String Tags { get; set; }
       
        //public virtual ApplicationUser User { get; set; }
        public virtual Category Category { get; set; }

    }
}