using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistrationApi.DBModel 
{
    public class Enrollment
    {
        [Key]
        public int enrollmentId { get; set; }

        public int userId { get; set; }

        public int courseId { get; set; }

        [Column(TypeName = "date")] 
        public DateTime enrollmentDate { get; set; }

        [MaxLength(60)]
        public string status { get; set; }
    }
}