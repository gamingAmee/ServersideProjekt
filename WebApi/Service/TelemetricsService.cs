using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Services
{
    public class TelemetricsService : ITelemetricsService
    {
        private HttpClient _httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://azureiothubfunctions.azurewebsites.net/")
        };

        public async Task<List<Telemetrics>> GetTelemetricsAsync()
        {
            string itemJson = await _httpClient.GetStringAsync($"api/GetTelemetryData");
            return JsonConvert.DeserializeObject<List<Telemetrics>>(itemJson);
        }
    }
}