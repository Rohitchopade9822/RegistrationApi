using Microsoft.AspNetCore.Authentication;
using RegistrationApi.DBModel;
using System;
using System.ComponentModel.DataAnnotations;

namespace RegistrationApi.DBModel
{
    public class Material
    {
        [Key] 
        public int materialId { get; set; }    
        
        public int courseId { get; set; }

        public string? title { get; set; }
            
        public string? description { get; set; }

        public string? URL { get; set; }

        public DateTime uploadDate { get; set; }

        public string? contentType { get; set; }

        public byte[]? upload_file { get; set; }

    }
}


