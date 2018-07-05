using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArquiteturaEventSourcing.Domain;
using ArquiteturaEventSourcing.Domain.Core.Data;
using ArquiteturaEventSourcing.Domain.Core.Events;
using ArquiteturaEventSourcing.Domain.Core.Validations;
using ArquiteturaEventSourcing.Domain.Users.Data;
using ArquiteturaEventSourcing.Domain.Users.Events;
using ArquiteturaEventSourcing.Infra.Data;
using ArquiteturaEventSourcing.Infra.DbContexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ArquiteturaEventSourcing.Api
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
            services.AddEntityFrameworkInMemoryDatabase().AddDbContext<EntitiesContext>(options => options.UseInMemoryDatabase("EntitiesDB"));
            services.AddEntityFrameworkInMemoryDatabase().AddDbContext<CommandsContext>(options => options.UseInMemoryDatabase("CommandsDB"));
            services.AddEntityFrameworkInMemoryDatabase().AddDbContext<EventsContext>(options => options.UseInMemoryDatabase("EventsDB"));

            RegisterDependencyInjection(services);

            var domainStartup = services.BuildServiceProvider().GetService<DomainStartup>();
            domainStartup.Start();

            //services.BuildServiceProvider().GetService<CommandsContext>().Database.Migrate();
            //services.BuildServiceProvider().GetService<EventsContext>().Database.Migrate();
            //services.BuildServiceProvider().GetService<EntitiesContext>().Database.Migrate();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddCors();
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

            app.UseCors(builder => builder
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin()
                .AllowCredentials()
            );

            app.UseHttpsRedirection();
            app.UseMvc();
        }

        private void RegisterDependencyInjection(IServiceCollection services)
        {
            services.AddSingleton<DomainEventHandler>();
            services.AddSingleton<DomainStartup>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<UserEventStream>();
            services.AddScoped<ICommandRepository, CommandRepository>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IUnityOfWork, UnityOfWork>();
            services.AddScoped<DomainEventBus>();
            services.AddScoped<CentralValidations>();
        }
    }
}
