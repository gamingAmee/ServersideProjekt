using WebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Services
{
    public interface ITelemetricsService
    {
        Task<List<Telemetrics>> GetTelemetricsAsync();
    }
}
