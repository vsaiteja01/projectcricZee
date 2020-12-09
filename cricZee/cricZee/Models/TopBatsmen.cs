using System;
using System.Collections.Generic;

#nullable disable

namespace cricZee.Models
{
    public partial class TopBatsmen
    {
        public int PlayerId { get; set; }
        public string Player { get; set; }
        public int Innings { get; set; }
        public int Runs { get; set; }
    }
}
