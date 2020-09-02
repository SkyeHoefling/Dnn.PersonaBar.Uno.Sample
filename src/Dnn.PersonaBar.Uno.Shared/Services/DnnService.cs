using System;
using System.Net.Http;
using System.Threading.Tasks;
using Dnn.PersonaBar.Uno.Shared.Models;

#if __WASM__
using Uno.UI.Wasm;
#endif

namespace Dnn.PersonaBar.Uno.Shared.Services
{
    public class DnnService
    {
        protected PersonaBarSettings Settings => ((App)App.Current).PersonaBarSettings;
        readonly HttpClient _httpClient;
        public DnnService()
        {
#if __WASM__
            var handler = new WasmHttpHandler();
            _httpClient = new HttpClient(handler);
#else
            _httpClient = new HttpClient();
#endif
            _httpClient.BaseAddress = new Uri(Settings.ApiRoute);
            _httpClient.DefaultRequestHeaders.Add("RequestVerificationToken", Settings.RequestVerificationToken);
        }

        public async Task<string> GetSettingAsync()
        {
            var response = await _httpClient.GetAsync("Home/Get");
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsStringAsync();

            return string.Empty;
        }

        public string UpdateSetting(string value)
        {
            throw new NotImplementedException();
        }
    }
}
