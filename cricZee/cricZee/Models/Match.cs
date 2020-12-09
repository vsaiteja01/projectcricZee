using System;
using System.Collections.Generic;

#nullable disable

namespace cricZee.Models
{
    public partial class Match
    {
        public int MatchId { get; set; }
        public string Team1 { get; set; }
        public string Team2 { get; set; }
        public string Result { get; set; }
    }
}
