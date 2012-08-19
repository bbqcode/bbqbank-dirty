using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using bbqbank.Helper;
using bbqbank.Models;
using bbqbank.ViewModels;

namespace bbqbank.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDatabaseContext _context;

        public HomeController(IDatabaseContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            var viewModel = new IndexViewModel
                                {
                                    AlexisTotalPaid = TotalPaid(Roommate.Alexis),
                                    AlexisTotalUsed = TotalUsed(Roommate.Alexis),
                                    MartinTotalPaid = TotalPaid(Roommate.Martin),
                                    MartinTotalUsed = TotalUsed(Roommate.Martin),
                                    AudeTotalPaid = TotalPaid(Roommate.Aude),
                                    AudeTotalUsed = TotalUsed(Roommate.Aude)
                                };
            viewModel.AlexisDiff = viewModel.AlexisTotalPaid - viewModel.AlexisTotalUsed;
            viewModel.MartinDiff = viewModel.MartinTotalPaid - viewModel.MartinTotalUsed;
            viewModel.AudeDiff = viewModel.AudeTotalPaid - viewModel.AudeTotalUsed;
            return View(viewModel);
        }

        private decimal TotalPaid(Roommate roommate)
        {
            var query = _context.Bills.WhoPaid(roommate);

            return query.Any() ? query.Sum(b => b.Total) : 0;
        }

        private decimal TotalUsed(Roommate roommate)
        {
            var items = FindItems(roommate);

            decimal total = 0;
            foreach (Item item in items)
            {
                decimal price = (item.HasTaxes) ? (item.Price*item.Bill.Total)/item.Bill.SubTotal : item.Price;
                total += price / HowManyUsed(item);
            }
            return total;
        }

        private IEnumerable<Item> FindItems(Roommate roommate)
        {
            List<Item> items;
            switch (roommate)
            {
                case Roommate.Alexis:
                    items = _context.Items.Where(i => i.HasAlexisUsed).ToList();
                    break;
                case Roommate.Martin:
                    items = _context.Items.Where(i => i.HasMartinUsed).ToList();
                    break;
                case Roommate.Aude:
                    items = _context.Items.Where(i => i.HasAudeUsed).ToList();
                    break;
                default:
                    throw new ArgumentException("Invalid roommate");
            }
            return items;
        }

        private int HowManyUsed(Item item)
        {
            var count = 0;
            if (item.HasAlexisUsed)
                count += 1;
            if (item.HasAudeUsed)
                count += 1;
            if (item.HasMartinUsed)
                count += 1;

            return count;
        }
    }
}