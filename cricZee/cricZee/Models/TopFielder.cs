using System;
using System.Collections.Generic;

#nullable disable

namespace cricZee.Models
{
    public partial class TopFielder
    {
        public int PlayerId { get; set; }
        public string Player { get; set; }
        public int Matches { get; set; }
        public int Catches { get; set; }
    }
}
