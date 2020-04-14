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
                 //추가 환경 설정 파일 지정
                 .AddJsonFile($"Settings/DotNetNoteSettings.json", optional: true)
                 .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; } //IConfiguration계층의 루트를 나타낸다.

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddControllersWithViews();

            //services.AddMvc(options => options.EnableEndpointRouting = false);

            //[DI] InfoService 클래스 의존성 주입
            //services.AddSingleton<InfoService>();
            //services.AddSingleton<IInfoService, InfoService>();

            //services.AddTransient<CopyrightService>();

            //services.AddScoped<ICopyrightService, CopyrightService>();


            //@inject 직접 주입

            //.net core mvc 주위의 DI해결 활성화
            //services.AddMvc();
            //services.AddScoped<ICopyrightService, CopyrightService>();

            //[DI] @inject 키워드로 뷰에 직접 클래스의 속성 / 메서드 값 출력
            //services.AddSingleton<CopyrightService>();

            //StronglyTyped
            //[!] Configuration: JSON파일의 데이터를 POCO클래스인 DotNetNoteSettings에 주입
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