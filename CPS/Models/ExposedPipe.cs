using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CPS.Models
{
    public partial class ExposedPipe
    {
        public ExposedPipe()
        {
            ExposedPipeImage = new HashSet<ExposedPipeImage>();
        }

        public int Id { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string Notes { get; set; }
        public DateTime InspectionDate { get; set; }
        public int RouteId { get; set; }
        public int UserId { get; set; }

        [JsonIgnore]
        public virtual Route Route { get; set; }
        [JsonIgnore]
        public virtual User User { get; set; }
        [JsonIgnore]
        public virtual ICollection<ExposedPipeImage> ExposedPipeImage { get; set; }
    }
}
