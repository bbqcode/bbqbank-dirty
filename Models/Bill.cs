using System;
using System.Collections.Generic;

namespace bbqbank.Models
{
    public class Bill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Total { get; set; }
        public decimal SubTotal { get; set; }
        public int WhoPaid { get; set; }
        public DateTime Date { get; set; }

        public DateTime CreatedAtUtc { get; set; }

        public List<Item> Items { get; set; }

        public string WhoPaidName()
        {
            var r = (Roommate) WhoPaid;
            return r.ToString();
        }

        public Bill()
        {
            Items = new List<Item>();
            CreatedAtUtc = DateTime.UtcNow;
        }
    }

    public enum Roommate
    {
        Alexis,
        Martin,
        Aude
    }
}
