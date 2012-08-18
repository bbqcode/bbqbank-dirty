using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
            var bills = _context.Bills.Include(b => b.Items).ToList();

            var alexisPaid = bills.Where(b => b.WhoPaid == Roommate.Alexis).Sum(b => b.Total);
/*
            decimal total;
            foreach(var items in bills.Where(b => b.Items.))

            var alexisUsed = bills.Sum(b => b.Items.Where(i => i.HasAlexisUsed))*/
            var viewModel = new IndexViewModel
                                           {
                                               
                                           };

            return View(viewModel);
        }
    }
}
