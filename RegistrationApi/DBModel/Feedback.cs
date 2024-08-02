using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RegistrationApi.DBModel
{
    public class Feedback
    {
        [Key]
 
        public int FeedbackId { get; set; }

        public int? UserId { get; set;}

        [MaxLength(500)]
        public string? feedback { get; set; }

        [Column("date")]
        public DateTime Date { get; set; }
    }
}
