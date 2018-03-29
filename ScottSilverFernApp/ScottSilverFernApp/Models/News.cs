﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ScottSilverFernApp.Models
{
    class News
    {
        public string Title { get; set; }
        public string ImageSmallAddr { get; set; }
        public string ImageBigAddr { get; set; }
        public string Publisher { get; set; }
        public DateTime DateTimeTime { get; set; }

        public string Article { get; set; }
        public string Abstract { get; set; }
    }
}
