using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using TrainingPortalBlazorApp.Models;

namespace TrainingPortalBlazorApp.Pages.Trainers
{
    public partial class ByType
    {
        [Parameter]
        public string type { get; set; }
        List<Trainer> trainers;
        [Inject]
        public IHttpClientFactory ClientFactory { get; set; }
        HttpClient client;
        [Inject]
        public ISession Session { get; set; }
        protected override async Task OnInitializedAsync()
        {
            client = ClientFactory.CreateClient("TrainerWebAPI");
            string token = await Session.GetTokenAsync();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            await GetAllTrainersByType();
        }
        private async Task GetAllTrainersByType()
        {
            trainers = await client.GetFromJsonAsync<List<Trainer>>($"ByType/{type}");
        }
    }
}
