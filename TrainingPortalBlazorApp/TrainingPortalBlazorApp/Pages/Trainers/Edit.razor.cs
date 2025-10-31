using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using TrainingPortalBlazorApp.Models;

namespace TrainingPortalBlazorApp.Pages.Trainers
{
    [Authorize]
    public partial class Edit
    {
        [Parameter]
        public string trainerid { get; set; }
        public Trainer trainer { get; set; } = new Trainer();
        [Inject]
        public IHttpClientFactory ClientFactory { get; set; }
        HttpClient client;
        [Inject]
        public NavigationManager NavManager { get; set; }
        [Inject]
        public ISession Session { get; set; }
        protected override async Task OnInitializedAsync()
        {
            client = ClientFactory.CreateClient("TrainerWebAPI");
            string token = await Session.GetTokenAsync();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            trainer = await client.GetFromJsonAsync<Trainer>($"ByTrainerId/{trainerid}");
        }
        private async Task UpdateTrainer()
        {
            await client.PutAsJsonAsync<Trainer>(trainerid, trainer);
            trainer = new Trainer();
            NavManager.NavigateTo("/trainer");
        }
    }
}
