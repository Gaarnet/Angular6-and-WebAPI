﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPITest.DTOs
{
    public class NavBarLinksDTO
    {
        public int Id { get; set; }
        public string LinkName { get; set; }
        public string LinkPath { get; set; }
        public string Icons { get; set; }
    }
}
