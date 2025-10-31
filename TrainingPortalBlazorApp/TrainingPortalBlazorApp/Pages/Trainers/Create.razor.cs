using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Net.Http.Json;
using TrainingPortalBlazorApp.Models;

namespace TrainingPortalBlazorApp.Pages.Trainers
{
    [Authorize]
    public partial class Create
    {
        public Trainer trainer { get; set; }
        [Inject]
        public IHttpClientFactory ClientFactory { get; set; }
        HttpClient client;
        [Inject]
        public NavigationManager NavManager { get; set; }
        [Inject]
        public ISession Session { get; set; }
        [Inject]
        public IJSRuntime jsRuntime { get; set; }
        string token;
        protected override async Task OnInitializedAsync()
        {
            client = ClientFactory.CreateClient("TrainerWebAPI");
            token = await Session.GetTokenAsync();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            trainer = new Trainer();
        }
        private async Task SaveTrainer()
        {
            await client.PostAsJsonAsync<Trainer>($"{token}", trainer);
            NavManager.NavigateTo("/trainer");
        }
    }
}
