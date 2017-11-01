using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace DevStudio.Models
{
    public class CommunityGroup
    {
        public int ID { get; set; }
        public string GroupName { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
    }

    public class CommunityGroupDBContext : DbContext
    {
        public DbSet<CommunityGroup> CommunityGroups { get; set; }
    }
}