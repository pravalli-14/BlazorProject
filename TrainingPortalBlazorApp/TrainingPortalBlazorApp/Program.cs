using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TrainingPortalBlazorApp.Authentication;
using TrainingPortalBlazorApp.Models;

namespace TrainingPortalBlazorApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddScoped<HttpClient>();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddSingleton<ISession, Session>();
            builder.Services.AddScoped<BrowserStorageService>();
            builder.Services.AddScoped<CustomAuthStateProvider>();
            builder.Services.AddScoped<AuthenticationStateProvider>(provider => provider.GetRequiredService<CustomAuthStateProvider>());
            builder.Services.AddHttpClient("EmployeeWebAPI", client =>
            {
                client.BaseAddress = new Uri(@"http://localhost:5255/api/Employee/");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });
            builder.Services.AddHttpClient("TechnologyWebAPI", client =>
            {
                client.BaseAddress = new Uri(@"http://localhost:5003/api/Technology/");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });
            builder.Services.AddHttpClient("TrainerWebAPI", client =>
            {
                client.BaseAddress = new Uri(@"http://localhost:5122/api/Trainer/");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });
            builder.Services.AddHttpClient("TrainingWebAPI", client =>
            {
                client.BaseAddress = new Uri(@"http://localhost:5077/api/Training/");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });
            builder.Services.AddHttpClient("TraineeWebAPI", client =>
            {
                client.BaseAddress = new Uri(@"http://localhost:5077/api/Trainee/");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });
            builder.Services.AddHttpClient("AuthAPI", client =>
            {
                client.BaseAddress = new Uri(@"http://localhost:5057/api/Auth/");
                client.DefaultRequestHeaders.Add("Accept", "application/text");
            });

            builder.Services.AddHttpClient("UserAPI", client =>
            {
                client.BaseAddress = new Uri(@"http://localhost:5057/api/User/");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });
            await builder.Build().RunAsync();
        }
    }
}
