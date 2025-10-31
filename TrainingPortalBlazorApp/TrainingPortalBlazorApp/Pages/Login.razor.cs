using Microsoft.AspNetCore.Components;
using TrainingPortalBlazorApp.Authentication;

namespace TrainingPortalBlazorApp.Pages
{
    public partial class Login
    {
        private string userId;
        private string password;
        public string ErrorMessage { get; set; } = string.Empty;
        [Inject]
        public NavigationManager NavManager { get; set; }
        [Inject]
        public CustomAuthStateProvider CustomAuthStateProvider { get; set; }
        private async Task LoginAsync()
        {
            try
            {
                await CustomAuthStateProvider.Login(userId, password);
                NavManager.NavigateTo("/");
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
    }
}
