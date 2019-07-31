using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace SoftwareProductApp.Client
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ViewModels.ISoftwareProductViewModel, ViewModels.SoftwareProductViewModel>();
            services.AddTransient<Models.ISoftwareProductModel, Models.SoftwareProductModel>();
            services.AddTransient<Services.ISoftwareProductService, Services.SoftwareProductService>();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
