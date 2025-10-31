using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using TrainingPortalBlazorApp.Models;

namespace TrainingPortalBlazorApp.Pages.Technologies
{
    [Authorize]
    public partial class Edit
    {
        [Parameter]
        public string techid { get; set; }
        public Technology technology { get; set; } = new Technology();
        [Inject]
        public IHttpClientFactory ClientFactory { get; set; }
        HttpClient client;
        [Inject]
        public NavigationManager NavManager { get; set; }
        [Inject]
        public ISession Session { get; set; }
        protected override async Task OnInitializedAsync()
        {
            client = ClientFactory.CreateClient("TechnologyWebAPI");
            string token = await Session.GetTokenAsync();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            technology = await client.GetFromJsonAsync<Technology>($"ById/{techid}");
        }
        private async Task UpdateTechnology()
        {
            await client.PutAsJsonAsync<Technology>(techid, technology);
            technology = new Technology();
            NavManager.NavigateTo("/technology");
        }
    }
}
