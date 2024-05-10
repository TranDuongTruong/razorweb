using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace razor08.efcore.Models
{
    //  [Table("Post")]
    public class Article
    {
        [Key]
        public int ID { get; set; }
        [StringLength(255)]
        [Required]
        [Column(TypeName = "nvarchar")]
        public string Title { get; set; }

        [DataType(DataType.Date)]
        [Required]
        
        public DateTime PublishDate { get; set; }

        [Column(TypeName = "ntext")]
        public string Content { set; get; }
    }
}