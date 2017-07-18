using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CargillApp.Models
{
    public class DataContext : DbContext
    {
        public DbSet<Event> Event { get; set; }
        public DbSet<EventLoc> EventLoc { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<EventUser> EventUser { get; set; }
    }
}