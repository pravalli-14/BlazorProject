using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Net.Http.Json;
using TrainingPortalBlazorApp.Models;

namespace TrainingPortalBlazorApp.Pages.Trainings
{
    [Authorize]
    public partial class CreateTrainee
    {
        [Parameter]
        public string trainingid { get; set; }
        public Trainee trainee { get; set; } = new Trainee();
        public List<Employee> EmployeeList { get; set; }=new List<Employee>();
        [Inject]
        //private IEmployeeRepository empRepo {get; set;}
        public IHttpClientFactory ClientFactory { get; set; }
        HttpClient client;
        [Inject]
        public NavigationManager NavManager { get; set; }
        [Inject]
        public ISession Session { get; set; }
        [Inject]
        public IJSRuntime jsRuntime { get; set; }
        protected override async Task OnInitializedAsync()
        {
            client = ClientFactory.CreateClient("TraineeWebAPI");
            string token = await Session.GetTokenAsync();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            trainee = new Trainee { 
            TrainingId = trainingid
            };
            EmployeeList = await client.GetFromJsonAsync<List<Employee>>("http://localhost:5255/api/Employee/");
        }
        private async Task SaveTrainee()
        {
            await client.PostAsJsonAsync<Trainee>("", trainee);
            NavManager.NavigateTo($"/trainees/{trainingid}");
        }
    }
}
