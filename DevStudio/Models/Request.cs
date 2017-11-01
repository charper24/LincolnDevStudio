using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace DevStudio.Models
{
    public class Request
    {
        public int ID { get; set; }
        public virtual Person Person { get; set; }
        public string RequestDescription { get; set; }
        public string RequestStatus { get; set; }
        public string RequestNotes { get; set; }
        public DateTime RequestDate { get; set; }
    }

    public class RequestDBContext : DbContext
    {
        public DbSet<Request> Requests { get; set; }
    }
}