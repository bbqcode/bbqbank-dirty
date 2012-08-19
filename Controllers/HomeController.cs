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
                if (item.HasTaxes)
                {
                    total += (item.Price*item.Bill.Total)/item.Bill.SubTotal;
                }
                else
                {
                    total += item.Price;
                }
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
    }
}