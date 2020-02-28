using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CPS.Models
{
    public partial class Tpimage
    {
        public int Id { get; set; }
        public string Link { get; set; }
        public string Notes { get; set; }
        public int TestPointId { get; set; }

        [JsonIgnore]
        public virtual TestPoint TestPoint { get; set; }
    }
}
