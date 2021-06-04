using System;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;

namespace Pedidos.Api.Extensions
{
    public static class ServicesExtensions
    {
        public static void ConfigureWebApi(this IServiceCollection services)
        {
            services.AddControllers()
                .AddFluentValidation()
                .AddNewtonsoftJson(opt =>
                {
                    opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                    opt.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                    opt.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                })
                .AddJsonOptions(opt => { opt.JsonSerializerOptions.PropertyNameCaseInsensitive = true; });
        }

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Pedidos.Api",
                    Version = "v1",
                    Description = "Api de Pedidos",
                    Contact = new OpenApiContact
                    {
                        Name = "Gustavo Kovalski Saporiti",
                        Email = "gustavokovalski.saporiti@gmail.co,",
                        Url = new Uri("https://github.com/Gustavokovalski")
                    },
                });
            });
        }
    }
}
