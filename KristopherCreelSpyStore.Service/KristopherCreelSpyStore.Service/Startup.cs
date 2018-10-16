using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using KristopherCreelSpyStore.DAL.Initializers;
using KristopherCreelSpyStore.DAL.EF;
using KristopherCreelSpyStore.DAL.Repos;
using KristopherCreelSpyStore.DAL.Repos.Interfaces;
using KristopherCreelSpyStore.Service.Filters;

namespace KristopherCreelSpyStore.Service
{
    public class Startup
    {
        private IHostingEnvironment _env;
        //public Startup(IHostingEnvironment env, ILoggerFactory loggerFactory)
        //{
        //}
        public Startup(IHostingEnvironment env)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
            _env = env;
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            /*
            services.AddMvcCore()
                .AddJsonFormatters(j =>
                {
                    j.ContractResolver = new DefaultContractResolver();
                    j.Formatting = Formatting.Indented;
                });
            */
            services.AddMvcCore(config =>
                config.Filters.Add(new SpyStoreExceptionFilter(_env.IsDevelopment())))
                .AddJsonFormatters(j =>
                {
                    j.ContractResolver = new DefaultContractResolver();
                    j.Formatting = Formatting.Indented;
                });
                
            // http://docs.asp.net/en/latest/security/cors.html
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                {
                    builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().AllowCredentials();
                });
            });
            //NOTE: Did not disable mixed mode running here
            services.AddDbContext<StoreContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("SpyStore")));

            services.AddScoped<ICategoryRepo, CategoryRepo>();
            services.AddScoped<IProductRepo, ProductRepo>();    
            services.AddScoped<ICustomerRepo, CustomerRepo>();
            services.AddScoped<IShoppingCartRepo, ShoppingCartRepo>();
            services.AddScoped<IOrderRepo, OrderRepo>();
            services.AddScoped<IOrderDetailRepo, OrderDetailRepo>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                loggerFactory.AddConsole(Configuration.GetSection("Logging"));
                loggerFactory.AddDebug();
            }

            if (env.IsDevelopment())
            {
                using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    StoreDataInitializer.InitializeData(app.ApplicationServices);
                }
            }
            app.UseCors("AllowAll");  // has to go before UseMvc

            app.UseMvc();
        }
    }
}
