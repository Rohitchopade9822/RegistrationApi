using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RegistrationApi.DBModel
{
    public class Course
    {
       
            [Key]
            public int courseId { get; set; }

            [Required]
            [MaxLength(50)]
            public string? title { get; set; }

            [MaxLength(50)]
            public string? description { get; set; }

            [Column(TypeName = "string")]
            public DateTime courseStartDate { get; set; }

            [Column(TypeName = "date")]
            public DateTime courseEndDate { get; set; }

            public int? userId { get; set; }

            [MaxLength(50)]
            public string? category { get; set; }

            [MaxLength(50)]
            public string? level { get; set; }
        
    }
}
