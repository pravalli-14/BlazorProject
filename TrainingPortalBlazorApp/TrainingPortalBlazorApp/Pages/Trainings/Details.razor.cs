using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using TrainingPortalBlazorApp.Models;

namespace TrainingPortalBlazorApp.Pages.Trainings
{
    [Authorize]
    public partial class Details
    {
        [Parameter]
        public string trainingid { get; set; }
        public Training training { get; set; } = new Training();
        [Inject]
        public IHttpClientFactory ClientFactory { get; set; }
        HttpClient client;
        [Inject]
        public ISession Session { get; set; }
        protected override async Task OnInitializedAsync()
        {
            client = ClientFactory.CreateClient("TrainingWebAPI");
            string token = await Session.GetTokenAsync();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            training = await client.GetFromJsonAsync<Training>($"ByTrainingId/{trainingid}");
        }
    }
}
