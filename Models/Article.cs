using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace razor08.efcore
{
    //  [Table("Post")]
    public class Article
    {
        [Key]
        public int ID { get; set; }
        [StringLength(255, MinimumLength = 5, ErrorMessage = "{0} nust between {2} and {1} character")]
        [Required(ErrorMessage = "{0} must type")]
        [Column(TypeName = "nvarchar")]
        [DisplayName("Tiêu đề")]
        public string Title { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "{0} must type")]
        [DisplayName("Ngày tạo")]

        public DateTime PublishDate { get; set; }

        [Column(TypeName = "ntext")]
        [DisplayName("Nội dung")]

        public string Content { set; get; }
    }
}