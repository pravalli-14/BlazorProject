using TrainingPortalBlazorApp.Models;
using Microsoft.AspNetCore.Components.Authorization;
using System.ComponentModel;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Threading.Tasks;

namespace TrainingPortalBlazorApp.Authentication
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private readonly BrowserStorageService browserStorageService;
        private static HttpClient client = new HttpClient() { BaseAddress = new Uri("http://localhost:5057/api/User/") };
        private static string token;
        private readonly ISession session;
        public UserDetails CurrentUser { get; set; }
        public CustomAuthStateProvider(BrowserStorageService bss, ISession session)
        {
            this.session = session;
            browserStorageService = bss;
            AuthenticationStateChanged += CustomAuthStateProvider_AuthenticationStateChanged;
        }
        private async void CustomAuthStateProvider_AuthenticationStateChanged(Task<AuthenticationState> task)
        {
            var authState = await task;
            if (authState is not null)
            {
                var idStr = authState.User.FindFirst(ClaimTypes.Name)?.Value;
                if (!string.IsNullOrWhiteSpace(idStr) && int.TryParse(idStr, out int id) && id > 0)
                {
                    CurrentUser = new UserDetails { UserId = idStr, RoleId = Convert.ToInt32(authState.User.FindFirst(ClaimTypes.Role)?.Value) };
                }
                return;
            }
            CurrentUser = new();
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var user = await browserStorageService.GetFromStorage<UserDetails>("user");
            if (user != null)
            {
                CurrentUser = user;
                var authState = GenerateAuthState(user);
                return authState;
            }
            else
            {
                CurrentUser = new UserDetails();
                return new AuthenticationState(new ClaimsPrincipal());
            }
        }
        private static AuthenticationState GenerateAuthState(UserDetails user)
        {
            Claim[] claims = new Claim[] {
                    new Claim(ClaimTypes.Name, user.UserId),
                    new Claim(ClaimTypes.Role, user.RoleId.ToString())
                };
            var identity = new ClaimsIdentity(claims, "Custom");
            var claimsPrincipal = new ClaimsPrincipal(identity);
            var authState = new AuthenticationState(claimsPrincipal);
            return authState;
        }
        public async Task Login(string userId, string password)
        {
            //client = clientFactory.CreateClient("UserAPI");
            token = await session.GetTokenAsync();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await client.GetAsync($"{userId}/{password}");
            if (response.IsSuccessStatusCode)
            {
                UserDetails userDetails = await response.Content.ReadFromJsonAsync<UserDetails>();
                await browserStorageService.SaveToStorage("user", userDetails);
                var authState = GenerateAuthState(userDetails);
                NotifyAuthenticationStateChanged(Task.FromResult(authState));
            }
            else
            {
                string error = await response.Content.ReadAsStringAsync();
                throw new Exception(error);
            }
        }
        public async Task RegisterAsync(string userId, string password)
        {
            HttpResponseMessage response = await client.PostAsync($"{userId}/{password}", null);
            if (!response.IsSuccessStatusCode)
            {
                string error = await response.Content.ReadAsStringAsync();
                throw new Exception(error);
            }
        }
        public async Task LogoutAsync()
        {
            await browserStorageService.RemoveFromStorage("user");
            var authState = new AuthenticationState(new ClaimsPrincipal());
            NotifyAuthenticationStateChanged(Task.FromResult(authState));
        }
    }
}
