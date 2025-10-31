using TrainingPortalBlazorApp.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Text.Json;
using System.Xml;

namespace TrainingPortalBlazorApp.Authentication
{
    public class BrowserStorageService
    {
        private const string storageType = "sessionStorage";
        private readonly IJSRuntime JSRuntime;
        public BrowserStorageService(IJSRuntime jSRuntime)
        {
            JSRuntime = jSRuntime;
        }
        public async Task SaveToStorage<TData>(string key, TData data)
        {
            await JSRuntime.InvokeVoidAsync($"{storageType}.setItem", key, Serialize(data));
        }
        public async Task<TData?> GetFromStorage<TData>(string key)
        {
            var serData = await JSRuntime.InvokeAsync<string>($"{storageType}.getItem", key);
            return Deserialize<TData?>(serData);
        }
        public async Task RemoveFromStorage(string key)
        {
            await JSRuntime.InvokeVoidAsync($"{storageType}.removeItem", key);
        }
        private static readonly JsonSerializerOptions serializerOptions = new JsonSerializerOptions();
        private static string Serialize<TData>(TData data)
        {
            return JsonSerializer.Serialize(data, serializerOptions);
        }
        private static TData? Deserialize<TData>(string json)
        {
            if (!string.IsNullOrWhiteSpace(json))
                return JsonSerializer.Deserialize<TData>(json, serializerOptions);
            else
                return default;
        }
    }
}
