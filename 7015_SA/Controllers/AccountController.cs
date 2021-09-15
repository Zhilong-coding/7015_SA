using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _7015_SA.Models;
using System.Data.SqlClient;

namespace _7015_SA.Controllers
{
    public class AccountController : Controller
    {
        SqlConnection con = new SqlConnection("Server=tcp:7015-prg522sa.database.windows.net,1433;Initial Catalog=PRG522DB;Persist Security Info=False;User ID=zhilong;Password=Iwantfood43;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=40");
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }


        public ActionResult Logoff()
        {
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(detail objDetail)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (Insert(objDetail))
                    {
                        ViewBag.Message = "Registered successfully";
                    }
                }
                return RedirectToAction("Login","Account");
            }
            catch
            {
                return RedirectToAction("Register", "Account");
            }
        }

        public bool Insert(detail objDetail)
        {
            string query = "Insert into details (userEmail, password, ConfirmPassword) values ('" + objDetail.userEmail.ToString() + "','" + objDetail.password.ToString() + "','" + objDetail.ConfirmPassword + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [HttpPost]

        public ActionResult Login(detail objDetail)
        {
            using (PRG522DBEntities1 db = new PRG522DBEntities1())
            {
                if (ModelState.IsValid)
                {
                    {
                        var obj = db.details.Where(a => a.userEmail.Equals(objDetail.userEmail) && a.password.Equals(objDetail.password)).FirstOrDefault();
                        if (obj != null)
                        {
                            Session["Email"] = obj.userEmail.ToString();
                            var EmailName = Session["Email"];
                            return RedirectToAction("Portfolio", "Home");
                        }
                    }
                }
                  return RedirectToAction("Index", "Home"); 
            }
        }
    }
}