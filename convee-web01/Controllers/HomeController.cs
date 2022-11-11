using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using convee_web01.Models;
using System.Data.Entity;
using PagedList;

namespace convee_web01.Controllers
{
    public class HomeController : Controller
    {
        private Riverside_HoldingsEntities db = new Riverside_HoldingsEntities();
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            int pageSize = 6;
            int pageNumber = (page ?? 1);

            ViewBag.CurrentSort = sortOrder;

            //
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            var clients = from c in db.CLIENTS select c;

            //return results according to search
            if (!String.IsNullOrEmpty(searchString))
            {
                clients = db.CLIENTS.Where(c => c.NAME.Contains(searchString));
            }

            ViewBag.CurrentFilter = searchString;

            return View(clients.ToList().ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Invoices(string id, int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);


            //access products model
            var invoicesVM = new ClientInvoicesVM();
            invoicesVM.Client = db.CLIENTS.Where(c => c.CLIENT_ID.Contains(id)).ToList();
            invoicesVM.Invoices = db.INVOICES.ToList().Where(i => i.CLIENT_NUMBER.Contains(id)).ToPagedList(pageNumber, pageSize);

            return View(invoicesVM);
        }

        //public ActionResult searchInvoices(string sortOrder, string currentFilter, string invString, int? page)
        //{
        //    int pageSize = 10;
        //    int pageNumber = (page ?? 1);
        //    ViewBag.CurrentSort = sortOrder;

        //    //
        //    if (invString != null)
        //    {
        //        page = 1;
        //    }
        //    else
        //    {
        //        invString = currentFilter;
        //    }

        //    //access products model
        //    var invoicesVM = new ClientInvoicesVM();
        //    invoicesVM.Client = db.CLIENTS.ToList();
        //    invoicesVM.Invoices = db.INVOICES.ToList().ToPagedList(pageNumber, pageSize);

        //    //return results according to search
        //    if (!String.IsNullOrEmpty(invString))
        //    {
        //        invoicesVM.Invoices = db.INVOICES.ToList().Where(p => p.INVOICE_NUM.Contains(invString)).ToPagedList(pageNumber, pageSize);
        //    }

        //    ViewBag.CurrentFilter = invString;

        //    return View("Invoices",invoicesVM);
        //}

        public ActionResult Details(string id)
        {
            return View(db.INVOICES.ToList().Where(i => i.INVOICE_NUM.Contains(id)));
        }

        public ActionResult Statements()
        {
            return View();
        }

        public ActionResult Clients(string sortOrder, string currentFilter, string searchString, int? page)
        {
            int pageSize = 6;
            int pageNumber = (page ?? 1);

            ViewBag.CurrentSort = sortOrder;

            //
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            var clients = from c in db.CLIENTS select c;

            //return results according to search
            if (!String.IsNullOrEmpty(searchString))
            {
                clients = db.CLIENTS.Where(c => c.NAME.Contains(searchString));
            }

            ViewBag.CurrentFilter = searchString;

            return View(clients.ToList().ToPagedList(pageNumber, pageSize));
        }
    }
}