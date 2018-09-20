using intex.DAL;
using intex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace intex.Controllers
{
    public class ClientController : Controller
    {
        static Customer user = null; //this tracks the user throughout the session
        private IntexContext db = new IntexContext(); //context variable
        static int i; //i used to transfer data between actions

        // GET: Client
        public ActionResult Index()
        {
            if (user == null) // if the user isn't logged in, redirect them
            {
                return RedirectToAction("Login");
            }

            return View(user);
        }

        public ActionResult SeeWorkOrders() 
        {
            // get work order details for the customer
            IEnumerable<WorkOrderInfo> orders =
                db.Database.SqlQuery<WorkOrderInfo>
                ("select w.WorkOrderID, CompoundName, LTNumber, " +
                " OrderDate, CompleteDate, StatusDescription," +
                " TotalPrice" +
                " from WorkOrder w " +
                " join [Status] s on s.StatusCode = w.StatusCode " +
                " left join Compound c on c.WorkOrderID = w.WorkOrderID " +
                " where w.CustomerID = " + user.CustomerID + ";");

            return View(orders); // send this as model
        }

        public ActionResult SeeOrderedAssays(int LT, DateTime? day)
        {
            // Ordered Assay Info from database
            IEnumerable<OrderedAssayInfo> assays =
                db.Database.SqlQuery<OrderedAssayInfo>
                ("select w.WorkOrderID, CompoundName, AssayName, LTNumber " +
                " from WorkOrder w " +
                " join Compound c on c.WorkOrderID = w.WorkOrderID " +
                " join OrderedAssay oa on oa.WorkOrderID = w.WorkOrderID " +
                " join Assay a on a.AssayID = oa.AssayID " +
                " where CustomerID = "+user.CustomerID+" " +
                " and LTNumber = "+LT+" " +
                " order by CompoundName;");

            ViewBag.Date = day; // pass this thru viewbag (to check if null in view)

            return View(assays);
        }

        public ActionResult SeeTestInfo(string name, int LT)
        {
            ViewBag.LT = LT; // pass this thru ViewVag to show use as labels in view
            ViewBag.Name = name;

            IEnumerable<TestInfo> info = // query the data 
                db.Database.SqlQuery<TestInfo>
                ("select ti.TestInstanceID, ti.TestStartTime, ti.TestEndTime, ti.ClearResult, ti.TestResult " +
                " from WorkOrder w " +
                " join Compound c on c.WorkOrderID = w.WorkOrderID " +
                " join OrderedAssay oa on oa.WorkOrderID = w.WorkOrderID " +
                " join Assay a on a.AssayID = oa.AssayID " +
                " join CompoundSequence cs on((cs.LTNumber = c.LTNumber) and(cs.AssayID = oa.AssayID)) " +
                " join[Sample] s on((s.LTNumber = cs.LTNumber) and(s.SequenceCode = cs.SequenceCode) and(s.AssayID = cs.AssayID)) " +
                " left join TestInstance ti on((ti.SampleID = s.SampleID) and(ti.LTNumber = s.LTNumber)) " +
                " where CustomerID = "+user.CustomerID+" " +
                " and c.LTNumber ="+LT+" "+
                " and a.AssayName = '"+name+"'" +
                " order by ti.TestInstanceID");

            return View(info); // send as model
        }

        [HttpGet]
        public ActionResult NewWorkOrder()
        {
            // this is used for the DropDown List in the view
            ViewBag.AssayID = new SelectList(db.Assay, "AssayID", "AssayName");
            return View();
        }

        [HttpPost]
        public ActionResult NewWorkOrder([Bind(Include = "WorkOrderID, AssayID")] AddWorkOrder form)
        {
            if (ModelState.IsValid) // check if is valid
            {
                OrderedAssay oa = new OrderedAssay // new Ordered Assay object
                {
                    WorkOrderID = i,
                    AssayID = form.AssayID,
                    ResultFile = null,
                    ScheduledDate = null,
                    CompletionDate = null
                };

                db.OrderedAssay.Add(oa); // update database
                db.SaveChanges();
            }

            ViewBag.AssayID = new SelectList(db.Assay, "AssayID", "AssayName"); // remake select list
            ViewBag.Message = "Assay was added to the work order"; // add this message to the viewbag
            return View(); // go back to the view
        }

        [HttpGet]
        public ActionResult StartWorkOrder()
        {
            return View(); // show this view
        }

        [HttpPost]
        public ActionResult StartWorkOrder([Bind(Include = "WorkOrderID, CompoundName, CompoundDescription, SpecialInstructions")] StartWorkOrder form)
        {
            if (ModelState.IsValid) // is model valid?
            {
                WorkOrder wo = new WorkOrder // workorder object
                {
                    WorkOrderID = db.WorkOrders.Max(w => w.WorkOrderID) + 1,
                    StatusCode = 1,
                    EmployeeID = null,
                    CustomerID = user.CustomerID,
                    OrderDate = DateTime.Now,
                    CompleteDate = null,
                    SpecialInstructions = form.SpecialInstructions,
                    QuotedPrice = null,
                    TotalPrice = null
                };

                Compound c = new Compound // cmpd object
                {
                    LTNumber = db.Compound.Max(x => x.LTNumber) + 1,
                    WorkOrderID = wo.WorkOrderID,
                    CompoundName = form.CompoundName,
                    CompoundDescription = form.CompoundDescription,
                    AppearanceDescription = null,
                    MolecularMass = null,
                    CombinedWeight = null,
                    MaxToleratedDose = null
                };

                db.Compound.Add(c);
                db.SaveChanges();

                // add objs to database

                i = wo.WorkOrderID;
                db.WorkOrders.Add(wo);
                db.SaveChanges();

                return RedirectToAction("NewWorkOrder");
            }

            return View();
        }

        public ActionResult OrderConf()
        {
            ViewBag.Name = user.CustFirstName; // give name to the confirmation view
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View(); // login view
        }

        [HttpPost]
        public ActionResult Login(FormCollection form)
        {
            string email = form["Email"].ToString(); // get params
            string password = form["Password"].ToString();

            if (email.Contains("drop") || password.Contains("drop")) //prevents agains SQL injection attack
            {
                return RedirectToAction("Index", "Home");
            }

            var cust = db.Customer.SqlQuery // get customers from db
                ("select * " +
                " from Customer " +
                " where CustEmail = '" + email + "' " +
                " and CustPassword = '" + password + "';").ToList();

            if (cust.Count > 0)
            {
                user = cust[0]; // user is the first from that query
                return RedirectToAction("Index"); // let them login
            }

            ViewBag.Message = "Login failed, please try again";
            return View();
        }

        public ActionResult CustomerService()
        {
            return View();
        }

        public ActionResult ShowQuotes()
        {
            //get info on quotes
            IEnumerable<LabAssayQuotes> quotes =
            db.Database.SqlQuery<LabAssayQuotes>
            ("Select Assay.AssayID, AssayName, AssayDescription, EstimatedTime, ([TestMaterialTotal] + [WageTotal] + [BaseTotal]) as [AssayQuote] " +
                "From Assay " +
                "Inner Join " +
                "(Select AssayID, Sum(MaterialTotal) As[TestMaterialTotal] " +
                "From    AssayTest at " +
                "Inner Join " +
                "(Select TestID, Sum(MaterialPrice) As[MaterialTotal] " +
                "From Material m " +
                "Inner Join TestMaterial tm " +
                "On m.MaterialID = tm.MaterialID " +
                "Group By TestID) z " +
                "On at.TestID = z.TestID " +
                "Group By AssayID) AS tmt " +
                "On Assay.AssayID = tmt.AssayID " +
                "Inner Join " +
                "(Select AssayID, Sum(((datepart(hour, TimeEstimate)) + (cast(datepart(minute, TimeEstimate) as money) / 60)) * 40) as [WageTotal] " +
                "From Test t " +
                "Inner Join  AssayTest at " +
                "On t.TestID = at.TestID " +
                "Group By AssayID) as wt " +
                "On Assay.AssayID = wt.AssayID " +
                "Inner Join " +
                "(Select AssayID, Sum(TestBasePrice) as [BaseTotal] " +
                "From AssayTest at " +
                "Inner Join Test t " +
                "ON at.TestID = t.TestID " +
                "Group By AssayID) as bt " +
                "ON Assay.AssayID = bt.AssayID " +
                "Order By AssayID;"
                );

            return View(quotes); //return to view
        }
    }
}