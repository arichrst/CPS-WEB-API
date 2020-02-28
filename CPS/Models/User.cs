using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CPS.Models
{
    public partial class User
    {
        public User()
        {
            ExposedPipe = new HashSet<ExposedPipe>();
            Route = new HashSet<Route>();
            TestPoint = new HashSet<TestPoint>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Token { get; set; }

        [JsonIgnore]
        public virtual ICollection<ExposedPipe> ExposedPipe { get; set; }
        [JsonIgnore]
        public virtual ICollection<Route> Route { get; set; }
        [JsonIgnore]
        public virtual ICollection<TestPoint> TestPoint { get; set; }
    }
}
