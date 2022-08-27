using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace benjamin_peterhans.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        // GET: Home
        public ActionResult Formular()
        {
            return View();
        }

        // POST: Formular
        [HttpPost]
        public ActionResult Formular(string name, string vorname, string email, string betreff, string meldung)
        {
            ViewBag.name = name;
            ViewBag.vorname = vorname;
            ViewBag.email = email;
            ViewBag.betreff = betreff;
            ViewBag.meldung = meldung;
            ViewBag.errorName = "";

            bool errorMessage = false;

            if (String.IsNullOrEmpty(name) || name.Length < 2)
            {
                ViewBag.errorName = "Bitte füllen Sie den Namen mit mehr als zwei Zeichen aus!";
                errorMessage = true;
            }
            if (String.IsNullOrEmpty(vorname) || vorname.Length < 2)
            {
                ViewBag.errorVorname = "Bitte füllen Sie den Vornamen mit mehr als zwei Zeichen aus!";
                errorMessage = true;
            }
            if (String.IsNullOrEmpty(email))
            {
                ViewBag.errorEmail = "Bitte geben Sie eine gültige Emailadresse ein!";
                errorMessage = true;
            }
            if (String.IsNullOrEmpty(betreff) || betreff.Length < 2)
            {
                ViewBag.errorBetreff = "Bitte füllen Sie den Betreff mit mehr als zwei Zeichen aus!";
                errorMessage = true;
            }
            if (String.IsNullOrEmpty(meldung))
            {
                ViewBag.errorMeldung = "Bitte füllen Sie die Meldung aus!";
                errorMessage = true;
            }

            if (errorMessage == false)
            {
                Session.Add("Bestaetigung", vorname + " " + name + " (" + email + ") Ihre Nachricht wurde gespeichert.\nVielen dank für das Absenden des Formulars!");
                return RedirectToAction("ThankYou");
            }
            else
            {
                return View();
            }
        }

        // Get: ThanYou
        public ActionResult ThankYou()
        {
            return View();
        }
    }
}