using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace API
{
    public class Startup
    {

        private readonly IConfiguration _config;
        public Startup(IConfiguration config)
        {
            _config = config;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<UnitOfWork>();
            services.AddScoped<IBoxRepository, BoxRepository>();
            services.AddScoped<IPolicyRepository, PolicyRepository>();
            services.AddControllers()
            .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore); ;
            // services.AddDbContext<ArchiveContext>(x =>
            //     x.UseSqlite(_config.GetConnectionString("DefaultConnection")));
            services.AddDbContext<ArchiveContext>(options
                => options.UseSqlServer(_config.GetConnectionString("abc-live")));

            services.AddCors(opt =>
                {
                    opt.AddPolicy("CorsPolicy", policy =>
                        {
                            policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200");
                        });
                });
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("CorsPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

// Server=tcp:pablosouzatest.database.windows.net,1433;Initial Catalog=testdb;Persist Security Info=False;User ID=paguirre82;Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;

// "Data source=archive.db"

