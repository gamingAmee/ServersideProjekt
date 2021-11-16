using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Data
{
    public class Telemetrics
    {
        public string Temperatur { get; set; }
        public string Humidity { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
