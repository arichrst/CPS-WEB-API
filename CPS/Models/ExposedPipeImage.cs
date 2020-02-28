using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CPS.Models
{
    public partial class ExposedPipeImage
    {
        public int Id { get; set; }
        public string Link { get; set; }
        public string Notes { get; set; }
        public int ExposedPipeId { get; set; }

        [JsonIgnore]
        public virtual ExposedPipe ExposedPipe { get; set; }
    }
}
