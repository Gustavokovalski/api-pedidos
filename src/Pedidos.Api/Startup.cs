using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pedidos.Api.Extensions;
using Pedidos.Api.Infrasctructure.Middlewares;
using Pedidos.CrossCutting.IoC;
using Pedidos.Domain.Command.Commands.CriarPedido;
using Pedidos.Domain.Query.Queries.ObterPedidos;
using Pedidos.Infrastructure.Data.Context;

namespace Pedidos.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DatabaseContext>();

            services.ConfigureWebApi();

            services.RegisterServices();

            //TODO
            services.AddAutoMapper(typeof(CriarPedidoCommand));

            services.AddAutoMapper(typeof(ObterPedidosQuery));

            services.AddMediatR(typeof(Startup));

            services.ConfigureSwagger();


            // Disable default API Model validation
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pedidos.Api v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            // Handler de Excecao default para erros não tratados
            // Só retorna excecao se estiver configurado no appsettings
            app.ConfigureExceptionHandler(Configuration.GetValue<bool>("InternalServerErrorWithException"));

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
