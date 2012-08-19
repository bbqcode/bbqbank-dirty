using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bbqbank.Helper
{
    public static class DecimalExtentions
    {
        public static string ToMoney(this decimal that)
        {
            return String.Format("{0:C}", that);
        }
    }
}