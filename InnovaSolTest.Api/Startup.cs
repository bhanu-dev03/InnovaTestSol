using AutoMapper;
using InnovaSolTest.Repositories.Interfaces;
using InnovaSolTest.Repositories.Interfaces.Base;
using InnovaSolTest.Repositories.Repositories;
using InnovaSolTest.Repositories.Repositories.Base;
using InnovaSolTest.Services.Interfaces;
using InnovaSolTest.Services.Managers;
using InnovaSolTest.Services.Mapper;
using InnovaSolTestData;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace InnovaSolTest.Api
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
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRegistrationService, UserRegistrationService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IDbProvider, SqlDbProvider>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddAutoMapper(typeof(AutoMapperProfile));

            //services.AddDbContext<InnovaDbContext>(options => { options.UseSqlServer(Configuration.GetConnectionString("InnovaDbConnection")); });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
