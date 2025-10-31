using Microsoft.AspNetCore.Components;
using TrainingPortalBlazorApp.Authentication;

namespace TrainingPortalBlazorApp.Pages
{
    public partial class Register
    {
        private string userId;
        private string password;
        private string retypePassword;
        public string ErrorMessage { get; set; } = string.Empty;
        [Inject]
        public NavigationManager NavManager { get; set; }
        [Inject]
        public CustomAuthStateProvider CustomAuthStateProvider { get; set; }
        private async Task RegisterAsync()
        {
            try
            {
                if (password == retypePassword)
                {
                    await CustomAuthStateProvider.RegisterAsync(userId, password);
                    NavManager.NavigateTo("/");
                }
                else
                {
                    ErrorMessage = "Passwords not matching";
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
    }
}
