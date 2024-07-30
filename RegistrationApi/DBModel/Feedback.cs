using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RegistrationApi.DBModel
{
    public class Feedback
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FeedbackId { get; set; }

        public int UserId { get; set;}

        [MaxLength(500)]
        public string FeedbackText { get; set; }

        [Column("date")]
        public DateTime Date { get; set; }
    }
}
