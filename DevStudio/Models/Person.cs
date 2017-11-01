using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace DevStudio.Models
{
    public class Person
    {
        public int ID { get; set; }
        public virtual CommunityGroup CommunityGroup { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class personDBContext : DbContext
    {
        public DbSet<Person> People { get; set; }
    }
}