using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace bbqbank.Models
{
    public interface IDatabaseContext
    {
        IDbSet<Bill> Bills { get; set; }
        IDbSet<Item> Items { get; set; }
        int SaveChanges();
    }

    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public IDbSet<Bill> Bills { get; set; }
        public IDbSet<Item> Items { get; set; }
    }
}