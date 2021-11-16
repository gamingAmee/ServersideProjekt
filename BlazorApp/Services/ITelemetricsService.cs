using BlazorApp.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp.Services
{
    public interface ITelemetricsService
    {
        Task<IEnumerable<Telemetrics>> GetTelemetricsAsync();
        //Task<bool> AddTelemetricsAsync(Telemetrics item);
        //Task<bool> UpdateTelemetricsAsync(Telemetrics item);
        //Task<bool> DeleteTelemetricsAsync(string id);
        //Task<Telemetrics> GetTelemetricsAsync(string id);
        
    }
}
