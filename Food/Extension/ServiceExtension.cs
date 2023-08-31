using Food.HttpService.Service;
using Food.Service;

namespace Food.Extension;

public static class ServiceExtension
{
   public static void ConfigureHttpService(this IServiceCollection services)
   {
      services.AddHttpClient<IHttpService, HttpService.Service.HttpService>();
      services.AddScoped<IHttpService, HttpService.Service.HttpService>();
   }

   public static void ConfigureBuaService(this IServiceCollection services)
   {
      services.AddScoped<IBUAService, BUASerrvice>();
   }
}