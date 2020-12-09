using System;
using System.Collections.Generic;

#nullable disable

namespace cricZee.Models
{
    public partial class PointsTable
    {
        public int TeamId { get; set; }
        public string Teams { get; set; }
        public int? Matches { get; set; }
        public int? Won { get; set; }
        public int? Lost { get; set; }
        public int? Tied { get; set; }
        public int? Points { get; set; }
        public string Nrr { get; set; }
        public int? Nrrposition { get; set; }
    }
}
