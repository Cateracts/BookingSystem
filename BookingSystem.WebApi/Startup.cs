using BookingSystem.Core.Entities;
using BookingSystem.Core.Interactions;
using BookingSystem.Core.Interfaces;
using BookingSystem.Core.Rules;
using BookingSystem.Persistence.EntityFramework;
using BookingSystem.Persistence.InMemory;
using BookingSystem.WebApi.Presenters;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            services.AddCors();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // TODO: Move to configuration
            var connection = @"Server=(localdb)\mssqllocaldb;Database=Bookings;Trusted_Connection=True;ConnectRetryCount=0";
            services.AddDbContext<BookingContext>
                (options => options.UseSqlServer(connection, builder => builder.MigrationsAssembly("BookingSystem.WebApi")));

            services.AddScoped<IGetBookingForDateRequest, GetBookingForDateInteractor>();
            services.AddScoped<IGetBookingForDateResponseHandler, GetBookingForDatePresenter>();            

            services.AddScoped<IMakeBookingRequest, MakeBookingInteractor>();
            services.AddScoped<IMakeBookingResponseHandler, MakeBookingPresenter>();

            services.AddScoped<IGetSpacesRequest, GetSpacesInteractor>();
            services.AddScoped<IGetSpacesResponseHandler, GetSpacesPresenter>();

            //services.AddSingleton<IBookingRepository, InMemoryBookingRepository>();
            //services.AddSingleton<ISpaceRepository, InMemorySpaceRepository>();
            services.AddScoped<IBookingRepository, EntityFrameworkBookingRepository>();
            services.AddScoped<ISpaceRepository, EntityFrameworkSpaceRepository>();

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

            // TODO: This is definitely not ideal. Need to revise.
            // TODO: Move Origins to configuration
            app.UseCors(options => options.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().AllowCredentials());

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/{webapiVersion}/swagger.json", webapiTitle);
            });

            app.UseMvc();
        }
    }
}
