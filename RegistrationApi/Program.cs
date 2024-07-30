using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.EntityFrameworkCore;
using RegistrationApi.Controllers.RegistrationApi.Controllers;
using RegistrationApi.DBModel;
using RegistrationApi.Repository;
using RegistrationApi.Services;
using System.Text.Json.Serialization;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
                    options.JsonSerializerOptions.IgnoreReadOnlyProperties = true; // Example: Ignore read-only properties
                    
                });
builder.Services.AddDbContext<MyAppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IMaterialRepository, MaterialRepository>();
builder.Services.AddScoped<ICourseMaterialRepository, CourseMaterialRepository>();
builder.Services.AddScoped<ICourse, CourseRepository>();
builder.Services.AddScoped<IEnrollment, EnrollmentRepository>();
builder.Services.AddScoped<IEnquiry, EnquiryRepository>();
builder.Services.AddScoped<IFeedback, FeedbackRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
