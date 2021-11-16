using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Data
{
    public class Telemetrics
    {
        public double Temperatur { get; set; }
        public double Humidity { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
