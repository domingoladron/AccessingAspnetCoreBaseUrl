using AccessingAspnetCoreBaseUrl.Data;
using Lamar.Microsoft.DependencyInjection;

namespace AccessingAspnetCoreBaseUrl
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            //Setup IoC using Lamar
            builder.Host.UseLamar((_, registry) =>
            {
                // Supports ASP.Net Core DI abstractions
                registry.AddMvc();
                registry.AddLogging();

                // Also exposes Lamar specific registrations
                // and functionality
                registry.Scan(s =>
                {
                    s.TheCallingAssembly();
                    s.AssemblyContainingType<Program>();
                    s.WithDefaultConventions();
                    s.LookForRegistries();
                });
            });


            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddSingleton<WeatherForecastService>();
            // Use API Controllers
            builder.Services.AddControllers();

            // Get the http context accessor
            builder.Services.AddHttpContextAccessor();

            // Get the Base URLs of this app so we can use it internally if need be
            var httpBaseUriAccessor = new HttpBaseUrlAccessor()
            {
                SiteUrlString = builder.WebHost.GetSetting(WebHostDefaults.ServerUrlsKey)
            };

            builder.Services.AddSingleton<IHttpBaseUrlAccessor>(httpBaseUriAccessor);


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");
            
            app.MapControllers();
            

            app.Run();
        }
    }
}