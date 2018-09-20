using intex.DAL;
using intex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace intex.Controllers
{
//    [Authorize]
    public class ManagerController : Controller
    {
        private IntexContext db = new IntexContext();

        // GET: Manager
        public ActionResult Index()
        {
            IEnumerable<Manager> manager = db.Database.SqlQuery<Manager>("SELECT SUM(Invoice.TotalPrice) AS sumInvoice, SUM(Invoice.Discount) AS sumDiscount, " +
                "AVG(WorkOrder.QuotedPrice) AS avgQuotedPrice, AVG(WorkOrder.TotalPrice) AS avgTotalPrice " +
                "FROM Invoice INNER JOIN WorkOrder ON WorkOrder.WorkOrderID = Invoice.WorkOrderID");
            return View(manager);
        }

        //public ActionResult Invoices()
        //{
        //    return View(db.Invoice.ToList());
        //}
    }
}