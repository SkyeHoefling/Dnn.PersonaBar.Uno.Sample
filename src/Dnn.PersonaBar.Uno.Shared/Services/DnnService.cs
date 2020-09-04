using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Dnn.PersonaBar.Uno.Models;
using Newtonsoft.Json;

#if __WASM__
using Uno.UI.Wasm;
#endif

namespace Dnn.PersonaBar.Uno.Services
{
    public class DnnService
    {
        protected PersonaBarSettings Settings => ((App)App.Current).PersonaBarSettings;
        readonly HttpClient _httpClient;
        public DnnService()
        {
            if (Settings == null || string.IsNullOrEmpty(Settings.ApiRoute))
                return;

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
            if (_httpClient == null)
                return string.Empty;

            var response = await _httpClient.GetAsync(Constants.SettingGet);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsStringAsync();

            return string.Empty;
        }

        public async Task<string> UpdateSetting(string value)
        {
            if (_httpClient == null)
                return string.Empty;

            var model = new ModuleSetting
            {
                Value = value
            };
            var json = JsonConvert.SerializeObject(model);
            var jsonContent = new StringContent(json, Encoding.UTF8, "application/json");

            var respnse = await _httpClient.PostAsync(Constants.SettingUpdate, jsonContent);
            if (respnse.IsSuccessStatusCode)
                return await respnse.Content.ReadAsStringAsync();

            return string.Empty;
        }

        public async Task<bool> Authorize()
        {
            if (_httpClient == null)
                return false;

            var response = await _httpClient.GetAsync(Constants.Authorize);
            return response.IsSuccessStatusCode;
        }
    }
}
