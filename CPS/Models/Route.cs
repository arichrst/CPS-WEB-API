using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CPS.Models
{
    public partial class Route
    {
        public Route()
        {
            ExposedPipe = new HashSet<ExposedPipe>();
            TestPoint = new HashSet<TestPoint>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string FromRegion { get; set; }
        public string ToRegion { get; set; }
        public double Distance { get; set; }
        public int UserId { get; set; }
        public double Diameter { get; set; }
        public string Field { get; set; }
        public string ProtectionCatodicType { get; set; }
        public string AnodeMaterial { get; set; }
        public string FieldTools { get; set; }
        public string PipeLengthTools { get; set; }
        public string DiameterTools { get; set; }
        public string CatodicProtectionTools { get; set; }
        public string AnodeMaterialTools { get; set; }
        public string FieldToolsBrand { get; set; }
        public string PipeLengthToolsBrand { get; set; }
        public string DiameterToolsBrand { get; set; }
        public string CatodicProtectionToolsBrand { get; set; }
        public string AnodeMaterialToolsBrand { get; set; }

        [JsonIgnore]
        public virtual User User { get; set; }
        [JsonIgnore]
        public virtual ICollection<ExposedPipe> ExposedPipe { get; set; }
        [JsonIgnore]
        public virtual ICollection<TestPoint> TestPoint { get; set; }
    }
}
