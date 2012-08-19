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
            var model = _context.Bills.ToList();
            return View(model);
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
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var bill = _context.Bills.Single(b => b.Id == id);
            _context.Bills.Remove(bill);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
