using TrainingPortalBlazorApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Net.Http.Json;

namespace TrainingPortalBlazorApp.Pages.Employees
{
    [Authorize]
    public partial class Create
    {
        public Employee employee { get; set; } 
        [Inject]
        public IHttpClientFactory ClientFactory { get; set; }
        HttpClient client;
        [Inject]
        public NavigationManager NavManager { get; set; }
        [Inject]
        public ISession Session { get; set; }
        [Inject]
        public IJSRuntime JSRuntime { get; set; }
        string token;
        protected override async Task OnInitializedAsync()
        {
            client = ClientFactory.CreateClient("EmployeeWebAPI");
            token = await Session.GetTokenAsync();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            employee = new Employee();
        }
        private async Task SaveEmployee()
        {
            await client.PostAsJsonAsync<Employee>($"{token}", employee);
            NavManager.NavigateTo("/employees");
        }
    }
}
