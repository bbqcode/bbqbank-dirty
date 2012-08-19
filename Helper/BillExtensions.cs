using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using bbqbank.Models;

namespace bbqbank.Helper
{
    public static class BillExtensions
    {
        public static IQueryable<Bill> WhoPaid(this IQueryable<Bill> that, Roommate roommate)
        {
            var roomateId = (int) roommate;
            return that.Where(x => x.WhoPaid == roomateId);
        }
    }
}