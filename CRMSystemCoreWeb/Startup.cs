using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.PlatformAbstractions;
using Yokogawa.Libraries.Business.Impl;
using Yokogawa.Libraries.Business.Interfaces;
using Yokogawa.Libraries.ORM.Impl;
using Yokogawa.Libraries.ORM.Interfaces;
using Yokogawa.Libraries.Repositories.Impl;
using Yokogawa.Libraries.Repositories.Interfaces;

namespace CRMSystemCoreWeb
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
            try
            {
                services.AddScoped<ICustomersContext, CustomersContext>();
                services.AddScoped<ICustomersRepository, CustomersRepository>();
                services.AddScoped<ICustomerValidator<string>, CustomerNameValidator>();
                services.AddScoped<ICustomersBusinessService, CustomersBusinessService>();

                services.AddDbContext<CustomersContext>(
                    dbContextOptionsBuilder =>
                    {
                        var encodedConnectionString = Environment.GetEnvironmentVariable("CRMSystemDBConnectionString");
                        var connectionString = Encoding.ASCII.GetString(
                            Convert.FromBase64String(encodedConnectionString));

                        if (dbContextOptionsBuilder != default(DbContextOptionsBuilder<CustomersContext>))
                            dbContextOptionsBuilder.UseSqlServer(connectionString);
                    });

                services.AddMvc();

                //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                //    .AddJwtBearer(
                //        jwtBearerOptions =>
                //        {
                //            jwtBearerOptions.Authority = @"https://login.microsoftonlin.com/iomegaazuregmail.onmicrosoft.com";
                //            jwtBearerOptions.Audience = @"https://iomegaazuregmail.onmicrosoft.com/52bb4f6c-f18f-4488-815d-fead824c5940";
                //        });

                services.AddSwaggerGen(
                    swaggerGenOptions =>
                    {
                        swaggerGenOptions.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info
                        {
                            Title = "Customers API",
                            Version = "v1",
                            Contact = new Swashbuckle.AspNetCore.Swagger.Contact { Email = "jd.ramkumar@gmail.com", Name = "Ramkumar JD", Url = @"http://people.intsol.in/jdramkumar" },
                            Description = "Simple CRM System Service",
                            License = new Swashbuckle.AspNetCore.Swagger.License { Name = "MIT", Url = "http://licenses.intsol.in/apis/mit" },
                            TermsOfService = "All Rights Reserved"
                        });

                        swaggerGenOptions.IncludeXmlComments(GetXmlCommentsPath());
                    });
            }
            catch { throw; }
        }

        private string GetXmlCommentsPath()
        {
            var app = PlatformServices.Default.Application;

            return Path.Combine(app.ApplicationBasePath, @"Yokogawa.Libraries.Web.Controllers.Impl.xml");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(
                swaggerUIOptions =>
                {
                    swaggerUIOptions.SwaggerEndpoint("/swagger/v1/swagger.json", "Customers API v1");
                });

            // app.UseAuthentication();

            app.UseMvc();
        }
    }
}
