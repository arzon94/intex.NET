using intex.DAL;
using intex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace intex.Controllers
{
    public class HomeController : Controller
    {
        private IntexContext db = new IntexContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        
        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Email(string name, string email, string question)
        {
            //as of now, the question parameter doesnt go anywhere.

            //only send an email if an email was provided
            if (email != null)
            {
                try
                {
                    //make new email and smtp object
                    MailMessage mail = new MailMessage("donny.brangle@gmail.com", email); //(from, to)
                    SmtpClient client = new SmtpClient
                    {
                        Port = 587, //port number for the gmail smtp
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,

                        //this is my alter-ego / email i use for possible scams (and homework, i guess), so don't go loggin in and be scammin strangers
                        Credentials = new System.Net.NetworkCredential("donny.brangle", "d0nnybrangl3"),
                        Host = "smtp.gmail.com",
                        EnableSsl = true
                    };

                    //this is what the email says
                    mail.Subject = "Northwest Labs Customer Support";
                    mail.Body = "Thank you for contacting Northwest Labs. A customer service representative will reply to your inquiry shortly.";

                    //send the email
                    client.Send(mail);
                }
                catch //this catches wrong email input and other possible issues
                {
                    //return "<p>Error: Email was not able to be sent, maybe the email address is invalid</p>";
                }
            }

            //display this to the view
            return RedirectToAction("Contact");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Login(FormCollection form, bool remember = false)
        {
            bool auth = false;
            Employee emp = null;

            IEnumerable<Employee> passwords =
                db.Employee.SqlQuery
                ("select * " +
                " from Employee");

            string email = form["Email"].ToString();
            string password = form["Password"].ToString();

            foreach (var e in passwords)
            {
                if (string.Equals(email, e.EmpEmail) && string.Equals(password, e.EmpPassword))
                {
                    FormsAuthentication.SetAuthCookie(email, remember);
                    emp = db.Employee.Find(e.EmployeeID);
                    auth = true;
                }
            }

            if (auth)
            {
                if (emp.PositionCode == 1)
                {
                    return RedirectToAction("Index", "Manager");
                }
                else
                {                                                               
                    return RedirectToAction("Index", "Lab");
                }
            }

            //else
            ViewBag.Message = "Login failed, please try again";
            return View();
        }
    }
}