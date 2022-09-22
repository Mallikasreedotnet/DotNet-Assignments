using Microsoft.AspNetCore.Mvc.ApiExplorer;
using SchoolManagementAPI.Middleware;
using Serilog;

namespace SchoolManagementAPI.Extensions
{
    public static class WebAppExtensions
    {
        public static void CreateMiddlewarePipeline(this WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                    }
                });
            }
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseHttpsRedirection();
            
            app.UseAuthorization();

            app.UseSerilogRequestLogging();

            app.MapControllers();
        }
    }
}
