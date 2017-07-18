using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CargillApp.Models
{
    public class Event
    {
        public int EventId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //public bool IsComplete { get; set; }
        //public virtual ICollection<EventLoc> EventLoc { get; set; }
    }
}