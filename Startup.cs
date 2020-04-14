using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DotNetNote.Services;
using DotNetNote.Settings;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Microsoft.Extensions.Logging;

namespace DotNetNote
{
    public class Startup
    {
        public Startup(IWebHostEnvironment env)
        {
            // Configuration = configuration;
            //[!] Configuration
            var builder = new ConfigurationBuilder()
                 .SetBasePath(env.ContentRootPath)
                 .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                 .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                 //[!] Configuration : Strongly Typed Configuration Setting
                 //�߰� ȯ�� ���� ���� ����
                 .AddJsonFile($"Settings/DotNetNoteSettings.json", optional: true)
                 .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; } //IConfiguration������ ��Ʈ�� ��Ÿ����.

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddControllersWithViews();

            //services.AddMvc(options => options.EnableEndpointRouting = false);

            //[DI] InfoService Ŭ���� ������ ����
            //services.AddSingleton<InfoService>();
            //services.AddSingleton<IInfoService, InfoService>();

            //services.AddTransient<CopyrightService>();

            //services.AddScoped<ICopyrightService, CopyrightService>();


            //@inject ���� ����

            //.net core mvc ������ DI�ذ� Ȱ��ȭ
            //services.AddMvc();
            //services.AddScoped<ICopyrightService, CopyrightService>();

            //[DI] @inject Ű����� �信 ���� Ŭ������ �Ӽ� / �޼��� �� ���
            //services.AddSingleton<CopyrightService>();

            //StronglyTyped
            //[!] Configuration: JSON������ �����͸� POCOŬ������ DotNetNoteSettings�� ����
            services.Configure<DotNetNoteSettings>(
                Configuration.GetSection("DotNetNoteSettings"));

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller=Home}/{action=Index}/{id?}");
            //});

            app.UseCors(options => options.WithOrigins("http://dotnetnote.azurewebsite.net/api/values"));
            app.UseCors(options => options.AllowAnyOrigin().WithMethods("GET"));
        }
    }
}