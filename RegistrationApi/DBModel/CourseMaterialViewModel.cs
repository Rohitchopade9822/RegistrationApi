using System;
using System.ComponentModel.DataAnnotations;

public class CourseMaterialViewModel
{
    [Key]
    public int CourseId { get; set; }

    [Required]
    [StringLength(50)]
    public string CourseTitle { get; set; }

    [StringLength(50)]
    public string CourseDescription { get; set; }

    [Required]
    public DateTime CourseStartDate { get; set; }

    [Required]
    public DateTime CourseEndDate { get; set; }

    [Required]
    public int UserId { get; set; }

    [Required]
    [StringLength(50)]
    public string Category { get; set; }

    [StringLength(50)]
    public string Level { get; set; }

    [Key]
    public int MaterialId { get; set; }

    [Required]
    [StringLength(50)]
    public string MaterialTitle { get; set; }

    [StringLength(500)]
    public string MaterialDescription { get; set; }

    [StringLength(1009)]
    public string MaterialURL { get; set; }

    [Required]
    public DateTime UploadDate { get; set; }

    [Required]
    [StringLength(50)]
    public string ContentType { get; set; }
}
