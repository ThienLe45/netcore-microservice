using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;
using Shopping.Client.Services;
using Microsoft.EntityFrameworkCore;
using Shopping.Client.Models;

namespace Shopping.Client
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

            services.AddHttpClient<IProductService, ProductService>();
            SD.ProductAPIBase = Configuration["ServiceUrls:ShoppingAPIUrl"];
            services.AddScoped<IProductService, ProductService>();



            //services.AddHttpClient("ShoppingAPIClient", client =>
            //{
            //    //client.BaseAddress = new Uri("http://localhost:5000/"); // Shopping.API url     
            //    client.BaseAddress = new Uri(Configuration["ShoppingAPIUrl"]);
            //});

            //services.AddHttpClient("ShoppingAPIClient", client =>
            //{
            //    //client.BaseAddress = new Uri("https://localhost:5001/"); // Movie.Client localhost
            //    client.BaseAddress = new Uri(Configuration["ShoppingAPIUrl"]);
            //    client.DefaultRequestHeaders.Clear();
            //    client.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
            //});



            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = Microsoft.AspNetCore.Http.SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<ShoppingClientContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("ShoppingClientContext")));
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
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
