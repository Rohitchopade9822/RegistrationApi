using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RegistrationApi.DBModel;

public partial class MyAppDbContext : DbContext
{
    public MyAppDbContext()
    {
    }

    public MyAppDbContext(DbContextOptions<MyAppDbContext> options)
        : base(options)
    {

    }
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     
    //public virtual DbSet<Userinfo> Userinfos { get; set; }
    
    public virtual DbSet<Material> Materials { get; set; }

    public virtual DbSet<CourseMaterialViewModel> CourseMaterialViewModels { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Enrollment> Enrollments { get; set; }

    public virtual DbSet<Enquiry> Enquiry { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<User> Users { get; set; }

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
        //modelBuilder.Entity<Userinfo>(entity =>
        //{
        //    entity.HasKey(e => e.UserId).HasName("PK__Userinfo__1788CC4C13F2EB39");

        //    entity.ToTable("Userinfo");

        //    entity.Property(e => e.UserId).ValueGeneratedNever(); 
        //    entity.Property(e => e.Email)
        //        .HasMaxLength(100)
        //        .IsUnicode(false);
        //    entity.Property(e => e.MobileNumber)
        //        .HasMaxLength(15)
        //        .IsUnicode(false);
        //    entity.Property(e => e.Password)
        //        .HasMaxLength(50)
        //        .IsUnicode(false);
        //    entity.Property(e => e.ProfileImage)
        //        .HasMaxLength(255)
        //        .IsUnicode(false);b
        //    entity.Property(e => e.Role)
        //        .HasMaxLength(10)
        //        .IsUnicode(false);
        //    entity.Property(e => e.Username)
        //        .HasMaxLength(100)
        //        .IsUnicode(false);
        //});
        //modelBuilder.Entity<Material>(entity =>
        //{
        //    entity.HasKey(e => e.materialId);
        //    entity.ToTable("Materials");

        //    entity.Property(e => e.courseId).IsRequired(true);
        //    entity.Property(e => e.title).IsRequired(false).HasMaxLength(50);
        //    entity.Property(e => e.description).IsRequired(false).HasMaxLength(500);
        //    entity.Property(e => e.URL).IsRequired(false).HasMaxLength(500);
        //    entity.Property(e => e.uploadDate).IsRequired(true);
        //    entity.Property(e => e.contentType).IsRequired(false).HasMaxLength(50);
        //});

        //OnModelCreatingPartial(modelBuilder);
    //}

   // partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
