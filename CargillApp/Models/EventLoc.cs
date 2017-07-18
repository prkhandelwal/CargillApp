using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CargillApp.Models
{
    public class EventLoc
    {
        public int EventLocID { get; set; }
        public int EventID { get; set; }
        public string Location { get; set; }
        public bool IsComplete { get; set; }
        public virtual Event Event { get; set; }
    }
}