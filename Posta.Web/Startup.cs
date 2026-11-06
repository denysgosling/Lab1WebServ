using Microsoft.AspNetCore.DataProtection;
namespace Posta.Web;
public sealed class Startup(IWebHostEnvironment environment)
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllersWithViews();
        services.AddDataProtection().PersistKeysToFileSystem(new DirectoryInfo(Path.Combine(environment.ContentRootPath, "App_Data", "Keys")));
        services.AddAntiforgery(options => options.Cookie.Name = "Posta.Antiforgery.Lab1");
    }
    public void Configure(WebApplication app)
    {
        app.UseExceptionHandler("/Home/Error");
        app.Use(async (context, next) => {
            context.Response.Headers["X-Content-Type-Options"] = "nosniff";
            await next();
        });
        app.UseStaticFiles();
        app.UseRouting();
        app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
    }
}
