using Microsoft.OpenApi.Models;

namespace ManagementSystemProject.Security;

public static class AddSwaggerGenService
{
    public static IServiceCollection AddSwaggerService(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please Enter a valid token",
                Name = "Authorization",
                Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Scheme = "Bearer"
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
             {
                  {
                     new OpenApiSecurityScheme
                      {
                         Reference = new OpenApiReference
                         {
                             Type=ReferenceType.SecurityScheme,
                             Id = "Bearer"
                         }
                      },
                     new string[]{ }
                  }
             });
        });

        return services;
    }

}
