using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DI.Core.Contracts;
using DI.Core.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DI.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;

namespace DI
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
   
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));


            services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            var signingKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(Configuration["Auth:Secret"]));


            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
            
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        // Clock skew compensates for server time drift.
                        // We recommend 5 minutes or less:
                        ClockSkew = TimeSpan.FromMinutes(5),
                        // Specify the key used to sign the token:
                        IssuerSigningKey = signingKey,
                       
                        RequireSignedTokens = true,
                        // Ensure the token hasn't expired:
                        RequireExpirationTime = true,
                        ValidateLifetime = true,
                        // Ensure the token audience matches our audience value (default true):
                        ValidateAudience = true,
                        ValidAudience = Configuration["Auth:Audience"],
                        // Ensure the token was issued by a trusted authorization server (default true):
                        ValidateIssuer = true,
                        ValidIssuer = Configuration["Auth:Issuer"]
                    };
                });
            services
                .AddScoped<ICrudRepository<DI.Core.Entities.Task, Guid>, CrudRepository<DI.Core.Entities.Task, Guid>>();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Dhabout Lguerda API",
                    Description = "Wadh3iyet jane7 el ta2ira \\_",
                    TermsOfService = "Nik ala 3ajla bil volant",
                    Contact = new Contact
                    {
                        Name = "Taxiste",
                        Email = string.Empty,
                        Url = "http://yahya-miboun.69"
                    },
                    License = new License
                    {
                        Name = "Ja3bou ma7loul",
                        Url = "https://sami-forja.xxx/permis"
                    }
                });
                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

                
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
       

            app.UseHttpsRedirection();
            app.UseStaticFiles();


            app.UseAuthentication();
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Dhabout Lguerda API V1");
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
