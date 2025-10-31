using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using TrainingPortalBlazorApp.Models;

namespace TrainingPortalBlazorApp.Pages.Trainings
{
    [Authorize]
    public partial class ByStatus
    {
        [Parameter]
        public string trainingid { get; set; }
        [Parameter]
        public string status { get; set; }
        List<Trainee> trainees;
        [Inject]
        public IHttpClientFactory ClientFactory { get; set; }
        HttpClient client;
        [Inject]
        public ISession Session { get; set; }
        protected override async Task OnInitializedAsync()
        {
            client = ClientFactory.CreateClient("TraineeWebAPI");
            string token = await Session.GetTokenAsync();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            await GetAllTraineesByEmpId();
        }
        private async Task GetAllTraineesByEmpId()
        {
            trainees = await client.GetFromJsonAsync<List<Trainee>>($"ByStatus/{status}");
        }
    }
}
