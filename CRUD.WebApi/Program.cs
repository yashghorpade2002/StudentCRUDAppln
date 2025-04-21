using CRUD.Business;
using CRUD.Business.Contracts;
using CRUD.Data.Contracts;
using CRUD.EF;
using CRUD.EF.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Adding service
builder.Services.AddScoped<IStudentAsyncRepository, StudentAsyncEFRepository>();
builder.Services.AddScoped<IStudentAsyncManager, StudentAsyncManager>();


builder.Services.AddDbContext<CrudDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("default"));
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options =>
{
    options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
});

app.UseAuthorization();

app.MapControllers();

app.Run();
