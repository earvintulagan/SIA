using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SIA.Models.Entity;
using SIA.Models.DTO;
using SIA.Models.Repository;
using System.Security.Cryptography;
using System.Text;



namespace SIA.Controllers
{

    
    public class HomeController : Controller
    {
        Registration db = new Registration();
        EncryptDecryptRepository encdec = new EncryptDecryptRepository();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Homepage()
        {
            return View();
        }

        

        public ActionResult Register()
        {
            return View();
        }

       

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult dataTransfer(RegistrationFormDTO data)
        {

            Account acc = new Account();

            acc.Firstname = data.Firstname;
            acc.Middlename = data.Middlename;
            acc.Lastname = data.Lastname;
            acc.Birthdate = data.Birthdate;
            acc.Username = data.Username;
            acc.Password = encdec.Encrypt(data.Username, data.Password);

            db.Accounts.Add(acc);
            db.SaveChanges();
            return View("Login");

        }

        public string checkUserName(string Username)
        {

            var checkStudentId = db.Accounts.Where(s => s.Username == Username).FirstOrDefault();
            if (checkStudentId != null)
            {
                return "false";
            }
            return "true";
        }

        /*Checker for Login*/
        public ActionResult Loginchecker(string username, string password)
        {
            if (ModelState.IsValid)
            {


                var f_password = encdec.Encrypt(username,password);
                var data = db.Accounts.Where(s => s.Username.Equals(username) && s.Password.Equals(f_password)).ToList();
                if (data.Count() > 0)
                {
                    //add session
                    
                    return RedirectToAction("Homepage");
                }
                else
                {
                    
                    return RedirectToAction("Login");
                }
            }
            return View();
        }





    }
}