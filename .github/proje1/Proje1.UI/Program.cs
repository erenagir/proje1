using Microsoft.AspNetCore.Authentication.Cookies;
using Proje1.UI.Configurations;
using Proje1.UI.Filters;

namespace Proje1.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews(opt => {
                opt.ModelValidatorProviders.Clear();
                opt.Filters.Add(new ActionExceptionFilter());
            });


            //Session
            builder.Services.AddSession(opt =>
            {
                opt.IdleTimeout = TimeSpan.FromMinutes(20);
            });

            //Custom Services
            builder.Services.AddDIServices();

            //Authentication

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
                opt =>
                {
                    opt.Events = new CookieAuthenticationEvents
                    {
                        OnRedirectToLogin = context =>
                        {

                            //Eðer admin tarafýnda login olmadan yetki gerektiren bir sayfaya gitmeye çalýþýrsa admin login gelsin
                            if (context.Request.Path.Value.Contains("admin"))
                            {
                                context.Response.Redirect("/login/signin");
                            }
                            else //sunum projesinde ise o projeye ait login gelsin
                            {
                                context.Response.Redirect("/login/signin");
                            }
                            return Task.CompletedTask;
                        }
                    };

                });


            //Authorization
            builder.Services.AddAuthorizationService();
            
            
            builder.Services.AddHttpContextAccessor();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
         

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}