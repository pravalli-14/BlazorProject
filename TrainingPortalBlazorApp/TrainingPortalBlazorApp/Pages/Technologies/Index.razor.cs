using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using TrainingPortalBlazorApp.Models;

namespace TrainingPortalBlazorApp.Pages.Technologies
{
    [Authorize]
    public partial class Index
    {
        List<Technology> technologies;
        [Inject]
        public IHttpClientFactory ClientFactory { get; set; }
        HttpClient client;
        [Inject]
        public ISession Session { get; set; }
        protected override async Task OnInitializedAsync()
        {
            client = ClientFactory.CreateClient("TechnologyWebAPI");
            await GetAllTechnologies();
        }
        private async Task GetAllTechnologies()
        {
            string token = await Session.GetTokenAsync();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            technologies = await client.GetFromJsonAsync<List<Technology>>("");
        }
    }
}
