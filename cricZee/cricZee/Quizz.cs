﻿using System;
using System.Collections.Generic;

#nullable disable

namespace cricZee
{
    public partial class Quizz
    {
        public int QuizzId { get; set; }
        public string Ques { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public string Option4 { get; set; }
        public string Correct { get; set; }
    }
}
