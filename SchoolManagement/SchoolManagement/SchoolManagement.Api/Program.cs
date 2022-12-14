using AutoMapper;
using SchoolManagement.Api.Extensions;
using SchoolManagement.Api.Infrastructure.Configuration;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();


#region Configure and Register AutoMapper
var config = new MapperConfiguration(config => config.AddProfile(new AutoMapperConfiguration()));
IMapper mapper = config.CreateMapper();
builder.Services.AddSingleton<IMapper>(mapper);
#endregion

Log.Logger = new LoggerConfiguration().CreateBootstrapLogger();
builder.Host.UseSerilog(((ctx, lc) => lc.ReadFrom.Configuration(ctx.Configuration)));


IConfiguration configuration = builder.Configuration;
builder.Services.RegisterSystemServices();
builder.Services.RegisterApplicationServices(configuration);


var app = builder.Build();
app.CreateMiddlewarePipeline();
app.Run();
