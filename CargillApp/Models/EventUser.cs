﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CargillApp.Models
{
    public class EventUser
    {
        public int EventUserID { get; set; }
        public int UserID { get; set; }
        public int EventID { get; set; }
        public bool Acknowledge { get; set; }
        public virtual User User { get; set; }
        public virtual Event Event { get; set; }
    }
}