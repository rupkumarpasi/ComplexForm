using Microsoft.EntityFrameworkCore;
using TrainingCRUD.Data;
using TrainingCRUD.Repository;
using TrainingCRUD.Service;
using TrainingCRUD.Automapper;
using TrainingCRUD.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost3000", policy =>
    {
        policy.WithOrigins("http://localhost:3000")  // Your Next.js dev server
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials(); // If you need cookies/auth
    });
});
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => { options.UseSqlServer(connectionString); });




// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IFileUploader,FileUploader>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddAutoMapper(typeof(Automapper));

var app = builder.Build();
app.UseCors("AllowLocalhost3000");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAuthorization();

app.MapControllers();

app.Run();
