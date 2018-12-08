using BookingSystem.Core.Entities;
using BookingSystem.Persistence.InMemory;
using BookingSystem.Core.Interactions;
using BookingSystem.Core.Interfaces;
using BookingSystem.Core.Rules;
using BookingSystem.WebApi.Presenters;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace BookingSystem.WebApi
{
    public class Startup
    {
        private readonly string webapiTitle = "BookingSystem.WebApi";
        private readonly string webapiVersion = "v1";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddScoped<IGetBookingForDateRequest, GetBookingForDateInteractor>();
            services.AddScoped<IGetBookingForDateResponseHandler, GetBookingForDatePresenter>();

            services.AddScoped<IMakeBookingRequest, MakeBookingInteractor>();
            services.AddScoped<IMakeBookingResponseHandler, MakeBookingPresenter>();

            services.AddSingleton<IBookingRepository, InMemoryBookingRepository>();

            services.AddScoped<IValidator<Booking>, BookingValidator>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(webapiVersion, new Info { Title = webapiTitle, Version = webapiVersion });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/{webapiVersion}/swagger.json", webapiTitle);
            });

            app.UseMvc();
        }
    }
}
