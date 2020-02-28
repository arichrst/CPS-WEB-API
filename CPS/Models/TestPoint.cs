using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CPS.Models
{
    public partial class TestPoint
    {
        public TestPoint()
        {
            Tpimage = new HashSet<Tpimage>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string Notes { get; set; }
        public DateTime InspectionDate { get; set; }
        public int RouteId { get; set; }
        public int UserId { get; set; }
        public double KpLocation { get; set; }
        public double NativePipe { get; set; }
        public double Anode { get; set; }
        public double Protection { get; set; }
        public double AnodePower { get; set; }
        public double SoilResistivity { get; set; }
        public double Ph { get; set; }
        public string LandCorrosivity { get; set; }

        [JsonIgnore]
        public virtual Route Route { get; set; }
        [JsonIgnore]
        public virtual User User { get; set; }
        [JsonIgnore]
        public virtual ICollection<Tpimage> Tpimage { get; set; }
    }
}
