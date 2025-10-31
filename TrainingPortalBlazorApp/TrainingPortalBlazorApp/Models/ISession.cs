namespace TrainingPortalBlazorApp.Models
{
    public interface ISession
    {
        Task SetTokenAsync(string token);
        Task<string> GetTokenAsync();
    }
}
