using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using StoreServices.Api.Author.Application;
using StoreServices.Api.Author.RabbitHandler;
using StoreServices.Api.Author.Repository;
using StoreServices.Mailing.Email.SendGrid.Implementations;
using StoreServices.Mailing.Email.SendGrid.Interfaces;
using StoreServices.RabbitMQ.Bus.EventQueue;
using StoreServices.RabbitMQ.Bus.Implementation;
using StoreServices.RabbitMQ.Bus.RabbitBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreServices.Api.Autor
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
            services.AddTransient<IEventHandler<EmailEventQueue>, EmailEventHandler>();
            services.AddSingleton<IRabbitEventBus, RabbitEventBus>(sp => {
                var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
                return new RabbitEventBus(sp.GetService<IMediator>(), scopeFactory);
            });

            services.AddSingleton<ISendGridSend, SendGridSend>();
            services.AddTransient<EmailEventHandler>();
            services.AddControllers().AddFluentValidation(cfg => cfg.RegisterValidatorsFromAssemblyContaining<New>());
            services.AddDbContext<ContextAuthor>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("ConexionDatabase"));
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "StoreServices.Api.Autor", Version = "v1" });
            });

            services.AddMediatR(typeof(New.Handler).Assembly);
            services.AddAutoMapper(typeof(Query.Handler));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "StoreServices.Api.Autor v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            var eventBus = app.ApplicationServices.GetRequiredService<IRabbitEventBus>();
            eventBus.Suscribe<EmailEventQueue, EmailEventHandler>();
        }
    }
}
