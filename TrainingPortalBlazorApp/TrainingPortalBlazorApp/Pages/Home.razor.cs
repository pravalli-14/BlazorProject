using Microsoft.AspNetCore.Components;
using TrainingPortalBlazorApp.Models;

namespace TrainingPortalBlazorApp.Pages
{
    public partial class Home
    {
        [Inject]
        public IHttpClientFactory ClientFactory { get; set; }
        HttpClient client;
        [Inject]
        public ISession Session { get; set; }
        protected override async Task OnInitializedAsync()
        {
            client = ClientFactory.CreateClient("AuthAPI");
            string userName = "pravallika@zelis.com";
            string role = "Admin";
            string secretKey = "My name is Pravalika working with Zelis India at Hyderabad office";
            string token = await client.GetStringAsync($"{userName}/{role}/{secretKey}");
            await Session.SetTokenAsync(token);
        }
    }
}
