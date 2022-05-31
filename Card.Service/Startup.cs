using Card.Service.Configuration;
using Card.Service.Middleware;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;
using System.Reflection;
using Microsoft.OpenApi.Models;
namespace Card.Service
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
            services.AddMvc(option => option.EnableEndpointRouting = false).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddMediatR(typeof(Startup));

            services.RegisterDependencyInjector();

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Customer Card",
                    Description = "Customer Card",
                });

                // using System.Reflection;
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                s.IncludeXmlComments(MontarPathArquivoXmlSwagger());
            });

            

        }

        private string MontarPathArquivoXmlSwagger()
        {
            string caminhoAplicacao =
                   PlatformServices.Default.Application.ApplicationBasePath;
            string nomeAplicacao =
                PlatformServices.Default.Application.ApplicationName;
            string caminhoXmlDoc =
                Path.Combine(caminhoAplicacao, $"{nomeAplicacao}.xml");

            return caminhoXmlDoc;
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }


            app.UseMiddleware<ErrorHandlingMiddleware>();

            app.UseHttpsRedirection();

            app.UseSwagger(options =>
            {
                options.SerializeAsV2 = true;
            });

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Customer Card");
                options.RoutePrefix = string.Empty;
            });

            app.UseMvc();
        }
    }
}
