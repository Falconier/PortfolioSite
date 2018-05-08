using Microsoft.AspNet.Identity;
using PortfolioSite.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PortfolioSite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ContactMe()
        {
            ContactForm model = new ContactForm();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ContactMe(Email model)
        {
            try
            {

                EmailService ems = new EmailService();
                IdentityMessage msg = new IdentityMessage();

                msg.Body = "<p>Email From: <bold>" + model.FromName + "</bold> " + model.FromEmail + "</bold> " + model.Subject + "</p><p>Message:</p><p>" + model.Body + "</p>" + Environment.NewLine +
                    "<p>This is a message from your portfolio site.The name and Email of the contacting person is above.</p>";

                msg.Destination = ConfigurationManager.AppSettings["emailto"];
                msg.Subject = "Portfolio Contact Email";
                await ems.SendMailAsync(msg);
                TempData["BlogMessage"] = "Your Email has been sent";

            }
            catch (Exception Ex)
            {
                //Console.WriteLine(Ex.Message);
                await Task.FromResult(0);
            }
            return RedirectToAction("Index");
        }

        public ActionResult ComingSoon()
        {
            return View();
        }

        public ActionResult ComingSoonFinancialPlanner()
        {
            return View();
        }

        public ActionResult ComingSoonXamarin()
        {
            return View();
        }
        public ActionResult DownForMaintenance()
        {
            return View();
        }
        public ActionResult JSExercise()
        {
            return View();
        }

        public ActionResult JQueryExercise()
        {
            return View();
        }

        public ActionResult AdvancedJSandJQueryExercise()
        {
            return View();
        }
        public ActionResult CalculatorExercise()
        {
            return View();
        }
        public ActionResult NumberGuess()
        {
            return View();
        }
        public ActionResult AlarmClock()
        {
            return View();
        }
    }
}
