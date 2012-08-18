using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bbqbank.Models;

namespace bbqbank.Controllers
{
    public class BillController : Controller
    {
        private readonly IDatabaseContext _context;

        public BillController(IDatabaseContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Create(Bill model)
        {
            _context.Bills.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Edit", "Bill");
        }

        public ActionResult Edit(int id)
        {
            var bill = _context.Bills.Include(b => b.Items).SingleOrDefault(b => b.Id == id);
            if(bill == null)
                return RedirectToAction("Index", "Bill");

            return View(bill);
        }
        
        [HttpPost]
        public ActionResult Edit(Bill model)
        {
            var bill = _context.Bills.Single(b => b.Id == model.Id);

            bill.Date = model.Date;
            bill.MetroPoints = model.MetroPoints;
            bill.Name = model.Name;
            bill.SubTotal = model.SubTotal;
            bill.Total = model.Total;
            bill.WhoPaid = model.WhoPaid;

            foreach (var item in bill.Items)
            {
                bill.Items.Remove(item);
            }
            bill.Items = model.Items;

            _context.SaveChanges();

            return View(bill);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var bill = _context.Bills.Single(b => b.Id == id);
            _context.Bills.Remove(bill);
            _context.SaveChanges();
        }
    }
}
