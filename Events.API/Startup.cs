﻿using Events.BLL;
using Events.BLL.Interfaces;
using Events.DAL;
using Events.DAL.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using EventBs = Events.BLL.EventBs;

namespace Events.API
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<EventsDbContext>();
            services.AddSwaggerDocument();

            #region Business Logic Injections
            services.AddTransient<IEventsBs, EventBs>();
            #endregion

            #region DAL Injections
            services.AddTransient<IEventDb, EventDb>();
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseMvc();
            app.UseOpenApi();
            app.UseSwaggerUi3();
        }
    }
}