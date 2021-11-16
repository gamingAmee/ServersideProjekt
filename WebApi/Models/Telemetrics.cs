using System;

namespace WebApi.Models
{
    public class Telemetrics
    {
        public int Id { get; set; }
        public double Temperatur { get; set; }
        public double Humidity { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
