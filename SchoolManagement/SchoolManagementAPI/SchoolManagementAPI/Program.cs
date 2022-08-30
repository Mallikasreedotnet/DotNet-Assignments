using AutoMapper;
using Microsoft.Data.SqlClient;
using SchoolManagement.Infrastructure.Repository.EntityFramework;
using SchoolManagementAPI.Configuration;
using System.Data.Common;
using System.Data;
using SchoolManagement.Core.Contracts.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

#region Configure and Register AutoMapper
var config = new MapperConfiguration(config => config.AddProfile(new AutoMapperConfiguration()));
IMapper mapper = config.CreateMapper();
builder.Services.AddSingleton<IMapper>(mapper);
#endregion

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddScoped<ITeacher, TeacherRepository>();
DbConnection connection = new SqlConnection(@"Server= (localDb)\MSSQLLocalDB; DataBase=SchoolManagementDb;Trusted_Connection=True;");
builder.Services.AddSingleton<IDbConnection>(connection);
builder.Services.AddTransient<IParentRepository, ParentRepository>();
builder.Services.AddTransient<IStudentRepository, StudentRepository>();
builder.Services.AddTransient<ITeacherRepository, TeacherRepository>();



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
