using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using TrainingPortalBlazorApp.Models;

namespace TrainingPortalBlazorApp.Pages.Trainings
{
    [Authorize]
    public partial class DeleteTrainee
    {
        [Parameter]
        public string trainingid { get; set; }
        [Parameter]
        public string empid { get; set; }
        public Trainee trainee { get; set; } = new Trainee();
        [Inject]
        public IHttpClientFactory ClientFactory { get; set; }
        HttpClient client;
        [Inject]
        public NavigationManager NavManager { get; set; }
        [Inject]
        public ISession Session { get; set; }
        protected override async Task OnInitializedAsync()
        {
            client = ClientFactory.CreateClient("TraineeWebAPI");
            string token = await Session.GetTokenAsync();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            trainee = await client.GetFromJsonAsync<Trainee>($"{trainingid}/{empid}");
        }
        private async Task DeleteTraineeTraining()
        {
            await client.DeleteAsync($"{trainingid}/{empid}");
            NavManager.NavigateTo($"/trainees/{trainingid}");
        }
    }
}
