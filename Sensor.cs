using System;
using System.ComponentModel;

namespace SensorApi
{
    public class Sensor
    {
        
        public int Id { get; set; }

        public string Name { get; set; }

        public string OwnerName { get; set; }

        public double[] GPS { get; set; }

        public string Glonass { get; set; }
        
        public int Ñharge { get; set; }

        public double Indication { get; set; }

        public DateTime Date { get; set; }
    }
}
