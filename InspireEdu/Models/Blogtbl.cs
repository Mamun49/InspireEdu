namespace InspireEdu.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    [Table("Blogtbl")]
    public partial class Blogtbl
    {
        [Key]
        public int BlogId { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Your Blog Title")]
        
        public string BlogTitle { get; set; }

        [StringLength(50)]
        [DisplayName("Blog Calagories")]
        public string BlogCat { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        [DisplayName("Blog Description")]
        public string BlogDesc { get; set; }
        [DisplayName("Insert Blog Image")]
        public string BlogImage { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
    }
}
