﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CargillApp.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Category { get; set; }
    }
}