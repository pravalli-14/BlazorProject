using TrainingPortalBlazorApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace TrainingPortalBlazorApp.Pages.Employees
{
    [Authorize]
    public partial class Index
    {
        List<Employee> employees;
        [Inject]
        public IHttpClientFactory ClientFactory { get; set; }
        HttpClient client;
        [Inject]
        public ISession Session { get; set; }
        protected override async Task OnInitializedAsync()
        {
            client = ClientFactory.CreateClient("EmployeeWebAPI");
            await GetAllEmployees();
        }
        private async Task GetAllEmployees()
        {
            string token = await Session.GetTokenAsync();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            employees = await client.GetFromJsonAsync<List<Employee>>("");
        }
    }
}
