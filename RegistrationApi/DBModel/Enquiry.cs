using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Enquiry
{
    [Key]
    public int EnquiryId { get; set; }

    [Required(ErrorMessage = "User ID is required.")]
    public int? UserId { get; set; }

    [Required(ErrorMessage = "Course ID is required.")]
    public int? CourseId { get; set; }

    [StringLength(90, ErrorMessage = "Subject cannot be longer than 90 characters.")]
    public string? Subject { get; set; }

    [StringLength(90, ErrorMessage = "Message cannot be longer than 90 characters.")]
    public string? Message { get; set; }

    [StringLength(90, ErrorMessage = "Enquiry Date cannot be longer than 90 characters.")]
    public string? EnquiryDate { get; set; }

    [StringLength(90, ErrorMessage = "Status cannot be longer than 90 characters.")]
    public string? Status { get; set; }

    [StringLength(90, ErrorMessage = "Response cannot be longer than 90 characters.")]
    public string? Response { get; set; }
}
