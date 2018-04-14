using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using MyBills.Domain.Repositories.Bills;
using MyBills.Domain.Services.Bills;
using MyBills.Infra.Repositories.Bills;
using Swashbuckle.AspNetCore.Swagger;
using System.IO;

namespace MyBills.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMvc();
            services.AddAutoMapper();

            services.AddSwaggerGen(c =>
            {
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;

                c.SwaggerDoc("v1", new Info { Title = "MyBillsAPI", Version = "v1" });
                c.IncludeXmlComments(basePath + "\\MyBills.API.xml");
            });

            services.AddSingleton<IConfiguration>(Configuration);

            //DI
            services.AddScoped<IBillRepository, BillRepository>();
            services.AddScoped<IBillService, BillService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyBills API V1");
            });

            app.UseMvc();

           
        }
    }
}
