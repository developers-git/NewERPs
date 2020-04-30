using Erps.DAO;
using Erps.DAO.security;
using Erps.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace Erps.Controllers
{// GET: Admin
 //[CustomAuthorize(RolesConfigKey = "RolesConfigKey")]
 // [CustomAuthorize(UsersConfigKey = "UsersConfigKey")]
    [CustomAuthorize(Roles = "User,Approver,BrokerAdmin,BrokerAdmin2,Admin", NotifyUrl = " /UnauthorizedPage")]
    // [CustomAuthorize(Users = "1")]
    public class UserAccountsController : Controller
    {
        SqlCommand cmd;

        SqlConnection con = new SqlConnection();

        // public string constr;
        public string constr2;
        public string sql;
        public System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter();
        public SqlConnection conn = new System.Data.SqlClient.SqlConnection();
        public SqlConnection conn2 = new System.Data.SqlClient.SqlConnection();

        private SBoardContext db = new SBoardContext();
        void openconn()
        { //constr = ConfigurationManager.ConnectionStrings["Constring"].ConnectionString;
          //  string constr = @"Data Source= " + ConfigurationSettings.AppSettings["Server"].ToString() + "; Initial Catalog= " + ConfigurationSettings.AppSettings["Database"].ToString() + ";Integrated Security=True";
            var constr = ConfigurationManager.ConnectionStrings["SBoardConnection"].ConnectionString;
            conn.ConnectionString = constr;
            conn.Open();
        }
        void closeconn()
        {
            conn.Close();
        }
        // GET: UserAccounts
        public async Task<ActionResult> Index()
        {
            string name2 = WebSecurity.CurrentUserName;
            var user2 = db.Users.ToList().Where(a => a.Email == name2);
            ViewBag.Users = "";
            foreach (var row in user2)
            {
                ViewBag.Users = row.FirstName + " " + row.LastName;
            }
            string name = WebSecurity.CurrentUserName;
            var user = db.Users.ToList().Where(a => a.Email == name);
            return View(user.ToList());
        }

        // GET: SystemUsers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            string name2 = WebSecurity.CurrentUserName;
            var user2 = db.Users.ToList().Where(a => a.Email == name2);
            ViewBag.Users = "";
            foreach (var row in user2)
            {
                ViewBag.Users = row.FirstName + " " + row.LastName;
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = await db.Users.FindAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = await db.Users.FindAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            string name2 = WebSecurity.CurrentUserName;
            var user2 = db.Users.ToList().Where(a => a.Email == name2);
            ViewBag.Users = "";
            foreach (var row in user2)
            {
                ViewBag.Users = row.FirstName + " " + row.LastName;
            }



            List<SelectListItem> selectlist2 = new List<SelectListItem>();
            selectlist2.Add(new SelectListItem() { Text = user.BrokerName, Value = user.BrokerName });

            ViewBag.Sell = selectlist2;
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "UserId,Username,Email,Password,ConfirmPassword,FirstName,LastName,IsActive,LockCount,CreateDate,role,BrokerName,BrokerCode")] User user)
        {
            var name = db.Users.ToList().Where(a => a.Email == WebSecurity.CurrentUserName);
            string username = "";
            foreach (var p in name)
            {
                username = p.Username;
            }
            string name3 = WebSecurity.CurrentUserName;
            var userw = db.Users.ToList().Where(a => a.Email == name3);
            int? myid = 0;
            string names = "";
            foreach (var row in userw)
            {
                myid = row.UserId;
                names = row.Username;
            }
            int check = db.Users.ToList().Where(a => a.Email == user.Email && a.UserId != user.UserId).Count();

            if (ModelState.IsValid)
            {


                //db.Entry(user).State = EntityState.Modified;
                db.Users.AddOrUpdate(user);
                await db.SaveChangesAsync(names);
                System.Web.HttpContext.Current.Session["NOT"] = "You have successfully updated the user";

                //updateuserroles
                //var roles = db.Roles.ToList().Where(a => a.RoleName == user.role);
                //int role = 0;
                //foreach (var c in roles)
                //{
                //    role = c.RoleId;
                //}

                //openconn();
                //sql = "Update UserRoles set RoleId='" + role + "' where UserId='" + user.UserId + "'";
                //cmd = new System.Data.SqlClient.SqlCommand(sql, conn);
                //cmd.ExecuteNonQuery();
                //closeconn();

                return RedirectToAction("Index");
            }
            string name2 = WebSecurity.CurrentUserName;
            var user2 = db.Users.ToList().Where(a => a.Email == name2);
            ViewBag.Users = "";
            foreach (var row in user2)
            {
                ViewBag.Users = row.FirstName + " " + row.LastName;
            }
            if (check >= 1)
            {
                var mod = ModelState.First(c => c.Key == "Email");  // this
                mod.Value.Errors.Add("Duplicate emails are not allowed");
            }



            ////Create List of SelectListItem
            List<SelectListItem> selectlist2 = new List<SelectListItem>();
            selectlist2.Add(new SelectListItem() { Text = user.BrokerName, Value = user.BrokerName });

            ViewBag.Sell = selectlist2;
            return View(user);
        }


        public async Task<ActionResult> ResetPassword(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = await db.Users.FindAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            string name2 = WebSecurity.CurrentUserName;
            var user2 = db.Users.ToList().Where(a => a.Email == name2);
            ViewBag.Users = "";
            foreach (var row in user2)
            {
                ViewBag.Users = row.FirstName + " " + row.LastName;
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword([Bind(Include = "UserId,Username,Email,Password,ConfirmPassword,FirstName,LastName,IsActive,LockCount,CreateDate,role")] User user)
        {
            var name = db.Users.ToList().Where(a => a.Email == WebSecurity.CurrentUserName);
            string username = "";
            foreach (var p in name)
            {
                username = p.Username;
            }
            string name3 = WebSecurity.CurrentUserName;
            var userw = db.Users.ToList().Where(a => a.Email == name3);
            int? myid = 0;
            string names = "";
            foreach (var row in userw)
            {
                myid = row.UserId;
                names = row.Username;
            }
            if (ModelState.IsValid)
            {

                user.Password = Request["Password"].ToString();
                user.ConfirmPassword = Request["ConfirmPassword"].ToString();
                user.Password = ComputeHash(user.Password, new SHA256CryptoServiceProvider());
                user.ConfirmPassword = ComputeHash(user.ConfirmPassword, new SHA256CryptoServiceProvider());
                //db.Entry(user).State = EntityState.Modified;
                db.Users.AddOrUpdate(user);
                await db.SaveChangesAsync(names);
                System.Web.HttpContext.Current.Session["NOT"] = "You have successfully reset the password";


                return RedirectToAction("Index");
            }
            string name2 = WebSecurity.CurrentUserName;
            var user2 = db.Users.ToList().Where(a => a.Email == name2);
            ViewBag.Users = "";
            foreach (var row in user2)
            {
                ViewBag.Users = row.FirstName + " " + row.LastName;
            }
            return View(user);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        //password  hashing function
        public string ComputeHash(string input, HashAlgorithm algorithm)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);

            Byte[] hashedBytes = algorithm.ComputeHash(inputBytes);

            return BitConverter.ToString(hashedBytes);
        }
    }
}
