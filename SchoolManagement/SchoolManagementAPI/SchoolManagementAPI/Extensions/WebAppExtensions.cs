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
                app.UseSwagger();
                app.UseSwaggerUI();
            }
          // app.UseResponseCompression();
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseSerilogRequestLogging();

            app.MapControllers();
        }
    }
}
