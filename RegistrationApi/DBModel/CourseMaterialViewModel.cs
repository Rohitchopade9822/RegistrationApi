using System;
using System.ComponentModel.DataAnnotations;

public class CourseMaterialViewModel
{
    [Key]
    public int CourseId { get; set; }

    

    public string? title { get; set; }

  
    public string? description { get; set; }

  
    public DateTime CourseStartDate { get; set; }

    
    public DateTime CourseEndDate { get; set; }

  
    public int UserId { get; set; }

   
   
    public string? Category { get; set; }

    
    public string? Level { get; set; }

    
    public int MaterialId { get; set; }


    
    public string? URL { get; set; }

    
    public DateTime UploadDate { get; set; }

    
    
    public string? ContentType { get; set; }
}
