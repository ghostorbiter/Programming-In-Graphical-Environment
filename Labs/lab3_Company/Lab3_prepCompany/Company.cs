using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_prepCompany
{
    public class Plane
    {
        public string Brand { get; set; }
        public string Registration { get; set; }
        public int Capacity { get; set; }
        public int Weight { get; set; }
        public List<Flight> Flights { get; set; }
    }

    public class Flight
    {
        public string Number { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime DepartureTime { get; set; }
    }
}