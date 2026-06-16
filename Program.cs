using Microsoft.AspNetCore.Authentication;
using Scalar.AspNetCore;
using TmsApi.Middleware;
using TmsApi.Services;

var builder = WebApplication.CreateBuilder(args);

// 🔹 Register services
builder.Services.AddControllers();
builder.Services.AddProblemDetails();

// Swagger + Scalar UI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Business services
builder.Services.AddSingleton<ICourseService, CourseService>();
builder.Services.AddSingleton<IEnrollmentService, EnrollmentService>();

//builder.Services.AddScoped<IEnrollmentService, EnrollmentService>();
//builder.Services.AddScoped<ICourseService, CourseService>();

// 🔹 Authentication & Authorization
builder.Services
    .AddAuthentication("Training")
    .AddScheme<AuthenticationSchemeOptions, TrainingAuthHandler>("Training", null);

builder.Services.AddAuthorization();

var app = builder.Build();

// 🔹 Development vs Production setup
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapScalarApiReference(); // Scalar UI
}
else
{
    app.UseExceptionHandler();
}

// 🔹 Middleware pipeline
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// 🔹 Test endpoint for error handling
app.MapGet("/api/error", () =>
{
    throw new InvalidOperationException("Simulated failure");
});

app.Run();
