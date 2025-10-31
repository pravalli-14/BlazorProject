using TrainingPortalBlazorApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Net.Http.Json;

namespace TrainingPortalBlazorApp.Pages.Employees
{
    [Authorize]
    public partial class Edit
    {
        [Parameter]
        public string eid { get; set; }
        public Employee employee { get; set; } = new Employee();
        [Inject]
        public IHttpClientFactory ClientFactory { get; set; }
        HttpClient client;
        [Inject]
        public NavigationManager NavManager { get; set; }
        [Inject]
        public ISession Session { get; set; }
        protected override async Task OnInitializedAsync()
        {
            client = ClientFactory.CreateClient("EmployeeWebAPI");
            string token = await Session.GetTokenAsync();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            employee = await client.GetFromJsonAsync<Employee>($"EmpId/{eid}");
        }
        private async Task UpdateEmployee()
        {
            await client.PutAsJsonAsync<Employee>(eid, employee);
            employee = new Employee();
            NavManager.NavigateTo("/employees");
        }
    }
}
