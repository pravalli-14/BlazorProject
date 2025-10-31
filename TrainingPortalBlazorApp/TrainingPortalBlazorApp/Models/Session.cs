namespace TrainingPortalBlazorApp.Models
{
    public class Session : ISession
    {
        private string token;
        public async Task<string> GetTokenAsync()
        {
            return token;
        }

        public async Task SetTokenAsync(string token)
        {
            this.token = token;
        }
    }
}
