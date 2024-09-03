using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class CourseMaterialViewModel
{
    [Key]
    public int? materialId { get; set; }

    public string? title { get; set; }

    public string? description { get; set; }

    public string? URL { get; set; }

    public string? contentType { get; set; }

    public string? upload_file { get; set; }

    public string? level { get; set; }


}
