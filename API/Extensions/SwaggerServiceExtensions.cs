using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace API.Extensions
{
    public static class SwaggerServiceExtensions
    {
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
             {
                 c.SwaggerDoc("v1", new OpenApiInfo { Title = "Editor API", Version = "v1" });
             });
            return services;

        }

        public static IApplicationBuilder UseSwaggerDocumention(this IApplicationBuilder app)
        {
            #region swagger Plugin
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Editor API v1"); });
            #endregion
            return app;
        }
    }
}