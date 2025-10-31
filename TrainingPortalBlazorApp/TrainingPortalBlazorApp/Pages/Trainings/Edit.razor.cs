using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using TrainingPortalBlazorApp.Models;

namespace TrainingPortalBlazorApp.Pages.Trainings
{
    [Authorize]
    public partial class Edit
    {
        [Parameter]
        public string trainingid { get; set; }
        public Training training { get; set; } = new Training();
        public List<Technology> TechnologyList { get; set; } = new();
        public List<Trainer> TrainerList { get; set; } = new();
        [Inject]
        public IHttpClientFactory ClientFactory { get; set; }
        HttpClient client;
        [Inject]
        public NavigationManager NavManager { get; set; }
        [Inject]
        public ISession Session { get; set; }
        protected override async Task OnInitializedAsync()
        {
            client = ClientFactory.CreateClient("TrainingWebAPI");
            string token = await Session.GetTokenAsync();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            training = await client.GetFromJsonAsync<Training>($"ByTrainingId/{trainingid}");
            TechnologyList = await client.GetFromJsonAsync<List<Technology>>("http://localhost:5003/api/Technology/");
            TrainerList = await client.GetFromJsonAsync<List<Trainer>>("http://localhost:5122/api/Trainer/");
        }
        private async Task UpdateTraining()
        {
            await client.PutAsJsonAsync<Training>(trainingid, training);
            training = new Training();
            NavManager.NavigateTo("/training");
        }
    }
}
