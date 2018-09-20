using intex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using intex.DAL;

namespace intex.Controllers
{
    [Authorize]
    public class LabController : Controller
    {

        private IntexContext db = new IntexContext();

        // GET: Lab
        public ActionResult Index()
        {
            return View();
        }

        //The main action to be used in this controller. It shows the main work orders
        public ActionResult LabDashboard()
        {

            // get the work order and compound information for the lab workers
            IEnumerable<LabDashboardInfo> lab =
                db.Database.SqlQuery<LabDashboardInfo>
                ("SELECT WorkOrder.WorkOrderID, CompoundName, " +
                "LTNumber, OrderDate, StatusDescription, CompleteDate " +
                "FROM    WorkOrder INNER JOIN  Compound " +
                "ON  WorkOrder.WorkOrderID = Compound.WorkOrderID " +
                "INNER JOIN  [Status] ON  WorkOrder.StatusCode = Status.StatusCode " +
                "Order By WorkOrder.WorkOrderID, LTNumber ;"
                    );

            return View(lab);
        }

        //This Method queries the database for specific data on a compound. It is passed the LTNumber
        public ActionResult LabCompound(int LT)
        {
            IEnumerable<LabCompoundInfo> compound =
                db.Database.SqlQuery<LabCompoundInfo>
                (
                    "Select  Compound.LTNumber, CompoundName, CompoundDescription, AppearanceDescription, MolecularMass, CombinedWeight, MaxToleratedDose, AssayName, Assay.AssayID, AssayDescription, OrderedAssay.ScheduledDate, OrderedAssay.CompletionDate, EstimatedTime, ([TestMaterialTotal] + [WageTotal] + [BaseTotal]) as [AssayQuote] " +
                    "From Compound " +
                    "Inner JOIN  OrderedAssay " +
                    "ON  Compound.WorkOrderID = OrderedAssay.WorkOrderID " +
                    "INNER JOIN  Assay " +
                    "ON  OrderedAssay.AssayID = Assay.AssayID " +
                    "INNER JOIN " +
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
                    "ON at.TestID = t.TestID "+
                    "Group By AssayID) as bt " +
                    "ON Assay.AssayID = bt.AssayID " +
                    "Inner Join CompoundSequence cs " +
                    "ON Compound.LTNumber = cs.LTNumber " +
                    "And cs.AssayID = OrderedAssay.AssayID " +
                    "Where Compound.LTNumber = " + LT + " " +
                    "Order By Compound.LTNumber " + ";");

                return View(compound);
        }

        //This Method queries for all of the tests in a specific assay for a specific compound
        public ActionResult LabTest(int LT, String AN)
        {
            IEnumerable<LabTestInfo> test =
                db.Database.SqlQuery<LabTestInfo>
                ("Select WorkOrderID, CompoundName, AssayName, a.AssayID, c.LTNumber, cs.SequenceCode, s.SampleID, s.TestID, TestInstanceID, TestStartTime, TestEndTime, ClearResult, TestResult " +
                    "From Assay a " +
                    "Inner Join CompoundSequence cs " +
                    "On a.AssayID = cs.AssayID " +
                    "Inner Join Sample s " +
                    "ON cs.LTNumber = s.LTNumber " +
                    "And cs.SequenceCode = s.SequenceCode " +
                    "Left Join TestInstance ti " +
                    "ON s.SampleID = ti.SampleID " +
                    "And s.LTNumber = ti.LTNumber " +
                    "And s.AssayID = ti.AssayID " +
                    "And s.TestID = ti.TestID " +
                    "Inner Join Compound c " +
                    "On cs.LTNumber = c.LTNumber " +                  
                    "Where c.LTNumber = " + LT + " " +
                    "And a.AssayID = '" + AN + "' "+
                    "Order By c.LTNumber, cs.SequenceCode, s.SampleID;"                
                );

            return View(test);
        }

        //This Method goes to a view to schedule assays
        public ActionResult ScheduleAssay()
        {
            return View();
        }
        
        //This method returns a short query of all of the Assays and their estimated costs
        public ActionResult LabAssayQuote()
        {
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
            return View(quotes);
        }

        //This method returns a query that simply lists all of the TestInstances
        public ActionResult LabTestList()
        {
            IEnumerable<LabTestInfo> testlist =
                db.Database.SqlQuery<LabTestInfo>
                ("Select WorkOrderID, CompoundName, AssayName, a.AssayID, c.LTNumber, cs.SequenceCode, s.SampleID, s.TestID, TestInstanceID, TestStartTime, TestEndTime, ClearResult, TestResult " +
                    "From Assay a " +
                    "Inner Join CompoundSequence cs " +
                    "On a.AssayID = cs.AssayID " +
                    "Inner Join Sample s " +
                    "ON cs.LTNumber = s.LTNumber " +
                    "And cs.SequenceCode = s.SequenceCode " +
                    "Left Join TestInstance ti " +
                    "ON s.SampleID = ti.SampleID " +
                    "And s.LTNumber = ti.LTNumber " +
                    "And s.AssayID = ti.AssayID " +
                    "And s.TestID = ti.TestID " +
                    "Inner Join Compound c " +
                    "On cs.LTNumber = c.LTNumber " +                  
                    "Order By c.LTNumber, cs.SequenceCode, s.SampleID;"
                );

            return View(testlist);
        }

        //This method returns all of the assays that have not yet been scheduled by the lab
        public ActionResult LabAssaySchedule()
        {
            IEnumerable<LabAssaySchedule> assaylist =
                db.Database.SqlQuery<LabAssaySchedule>
                ("Select WorkOrderID, AssayName, AssayDescription, ScheduledDate, CompletionDate, EstimatedTime " +
                    "From OrderedAssay " +
                    "Inner Join  Assay " +
                    "On Assay.AssayID = OrderedAssay.AssayID " +
                    "Where ScheduledDate IS NULL " +
                    "Order By WorkOrderID;"); 

            return View(assaylist);
        }
    }
}