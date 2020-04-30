using Erps.DAO;
using Erps.DAO.security;
using System;
using System.Linq;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace Erps.Controllers
{// GET: Admin
 //[CustomAuthorize(RolesConfigKey = "RolesConfigKey")]
 // [CustomAuthorize(UsersConfigKey = "UsersConfigKey")]
    [CustomAuthorize(Roles = "Admin,BrokerAdmin,BrokerAdmin2,approver,User")]
    // [CustomAuthorize(Users = "1")]
    public class BrokerAdminController : Controller
    {
        private SBoardContext db = new SBoardContext();
        public ActionResult Index()
        {

            string n1 = "";
            string n2 = "";
            try
            {
                string name = WebSecurity.CurrentUserName;
                var user = db.Users.ToList().Where(a => a.Email == name);
                ViewBag.Users = "";
                foreach (var row in user)
                {
                    ViewBag.Users = row.FirstName + " " + row.LastName;
                }


                var c = db.Users.ToList().Where(a => a.Email == WebSecurity.CurrentUserName);
                string vx = "";
                foreach (var d in c)
                {
                    vx = d.BrokerCode;
                }

            }
            catch (Exception)
            {


            }
            ViewBag.Broker = n1;
            ViewBag.BrokerCode = n2;


            return View();
        }


        public ActionResult Unlock()
        {
            return View();
        }
    }
}