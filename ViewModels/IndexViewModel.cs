using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bbqbank.ViewModels
{
    public class IndexViewModel
    {
        public decimal AlexisTotalPaid { get; set; }
        public decimal AlexisTotalUsed { get; set; }

        public decimal AudeTotalPaid { get; set; }
        public decimal AudeTotalUsed { get; set; }

        public decimal MartinTotalUsed { get; set; }
        public decimal MartinTotalPaid { get; set; }
    }
}