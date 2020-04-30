using Erps.DAO;
using Erps.DAO.security;
using Erps.Models;
using PagedList;
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
{ //[CustomAuthorize(RolesConfigKey = "RolesConfigKey")]
  // [CustomAuthorize(UsersConfigKey = "UsersConfigKey")]
    [CustomAuthorize(Roles = "Admin,User,Approver,BrokerAdmin,BrokerAdmin2", NotifyUrl = " /UnauthorizedPage")]
    // [CustomAuthorize(Users = "1")]
    public class UsersController : Controller
    {
        private SBoardContext db = new SBoardContext();
        SqlCommand cmd;

        SqlConnection con = new SqlConnection();

        // public string constr;
        public string constr2;
        public string sql;
        public System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter();
        public SqlConnection conn = new System.Data.SqlClient.SqlConnection();
        public SqlConnection conn2 = new System.Data.SqlClient.SqlConnection();
        // GET: Users
        public async Task<ActionResult> Index(string sortOrder, int? page)
        {
            string name2 = WebSecurity.CurrentUserName;
            var user2 = db.Users.ToList().Where(a => a.Email == name2);
            ViewBag.Users = "";
            foreach (var row in user2)
            {
                ViewBag.Users = row.FirstName + " " + row.LastName;
            }

            var users = from s in db.Users
                        select s;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            switch (sortOrder)
            {
                case "name_desc":
                    users = users.OrderByDescending(s => s.Username);
                    break;

                case "Date":
                    users = users.OrderBy(s => s.CreateDate);
                    break;
                case "date_desc":
                    users = users.OrderByDescending(s => s.CreateDate);
                    break;

                default:
                    users = users.OrderBy(s => s.UserId);
                    break;
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(users.ToPagedList(pageNumber, pageSize));
            // return View(await db.Users.ToListAsync());
        }

        // GET: Users/Details/5
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

        // GET: Users/Create
        public ActionResult Create()
        {
            string name2 = WebSecurity.CurrentUserName;
            var user2 = db.Users.ToList().Where(a => a.Email == name2);
            ViewBag.Users = "";
            foreach (var row in user2)
            {
                ViewBag.Users = row.FirstName + " " + row.LastName;
            }
            var list3 = db.Roles.ToList();

            //Create List of SelectListItem
            List<SelectListItem> selectlist = new List<SelectListItem>();
            selectlist.Add(new SelectListItem() { Text = "", Value = "" });
            foreach (var row in list3)
            {
                //Adding every record to list  

                selectlist.Add(new SelectListItem { Text = row.RoleName, Value = row.RoleName.ToString() });
            }
            ViewBag.Role = selectlist;


            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "UserId,Username,Email,Password,ConfirmPassword,FirstName,LastName,IsActive,LockCount,CreateDate,role,BrokerName,BrokerCode")] User user)
        {
            var name = db.Users.ToList().Where(a => a.Email == WebSecurity.CurrentUserName);
            string username = "";
            foreach (var p in name)
            {
                username = p.Username;
            }
            var list3 = db.Roles.ToList();

            //Create List of SelectListItem
            List<SelectListItem> selectlist = new List<SelectListItem>();
            selectlist.Add(new SelectListItem() { Text = "", Value = "" });
            foreach (var row in list3)
            {
                //Adding every record to list  

                selectlist.Add(new SelectListItem { Text = row.RoleName, Value = row.RoleName.ToString() });
            }
            ViewBag.Role = selectlist;
            int check = db.Users.ToList().Where(a => a.Email == user.Email).Count();
            if (check >= 1)
            {
                var mod = ModelState.First(c => c.Key == "Email");  // this
                mod.Value.Errors.Add("Duplicate emails are not allowed");
            }

            string h = "";

            if (user.BrokerCode == "")
            {
                user.BrokerCode = "MORCO";
                user.BrokerName = "Dry Associates";
            }
            if (ModelState.IsValid && check < 1)
            {
                string name4 = WebSecurity.CurrentUserName;
                var userw = db.Users.ToList().Where(a => a.Email == name4);
                int? myid = 0;
                string names = "";
                foreach (var row in userw)
                {
                    myid = row.UserId;
                    names = row.Username;
                }

                if (Request["role"] != "")
                {
                    //Role role = new Role {RoleName = Request["Roles"] };
                    string fullname = Request["role"];
                    var role = db.Roles.ToList().Where(a => a.RoleName == fullname);



                    //sql query


                    user.Password = Request["Password"].ToString();
                    user.ConfirmPassword = Request["ConfirmPassword"].ToString();
                    user.Password = ComputeHash(user.Password, new SHA256CryptoServiceProvider());
                    user.ConfirmPassword = ComputeHash(user.ConfirmPassword, new SHA256CryptoServiceProvider());
                    user.CreateDate = DateTime.Now;
                    user.LockCount = 0;
                    user.role = Request["role"].ToString();
                    if (user.BrokerCode == null)
                    {
                        user.BrokerCode = "MORCO";
                        user.BrokerName = "Dry Associates";
                    }
                    db.Users.Add(user);
                    await db.SaveChangesAsync(names);
                    System.Web.HttpContext.Current.Session["NOT"] = "You have successfully added the user";



                    int roleid = 0;
                    int userid = 0;
                    foreach (var row in role)
                    {
                        roleid = row.RoleId;
                    }
                    int user2 = db.Users.Max(a => a.UserId);

                    userid = user2;
                    string cs = ConfigurationManager.ConnectionStrings["SBoardConnection"].ConnectionString;

                    using (SqlConnection cn = new SqlConnection(cs))
                    {
                        string sql =
                            "INSERT INTO UserRoles (UserId,RoleId) VALUES (@UserId,@RoleId)";
                        SqlCommand cmd = new SqlCommand(sql);
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = cn;
                        cmd.Parameters.AddWithValue("@UserId", userid);
                        cmd.Parameters.AddWithValue("@RoleId", roleid);

                        cn.Open();
                        try
                        {
                            cmd.ExecuteNonQuery();
                            cn.Close();
                        }
                        catch (Exception)
                        {

                            throw;
                        }

                    }
                    // user.Roles.Add(role);
                }
                return RedirectToAction("Index");
            }
            else
            {

            }
            string name2 = WebSecurity.CurrentUserName;
            var user3 = db.Users.ToList().Where(a => a.Email == name2);
            ViewBag.Users = "";
            foreach (var row in user3)
            {
                ViewBag.Users = row.FirstName + " " + row.LastName;
            }

            ////Create List of SelectListItem
            List<SelectListItem> selectlist2 = new List<SelectListItem>();
            selectlist2.Add(new SelectListItem() { Text = user.BrokerName, Value = user.BrokerName });

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




            ////Create List of SelectListItem
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


            if (user.BrokerName == null)
            {
                user.BrokerCode = "MORCO";
                user.BrokerName = "Dry Associates";
            }
            if (ModelState.IsValid)
            {


                //db.Entry(user).State = EntityState.Modified;
                db.Users.AddOrUpdate(user);
                await db.SaveChangesAsync(names);
                System.Web.HttpContext.Current.Session["NOT"] = "You have successfully updated the user";

                //updateuserroles
                var roles = db.Roles.ToList().Where(a => a.RoleName == user.role);
                int role = 0;
                foreach (var c in roles)
                {
                    role = c.RoleId;
                }

                openconn();
                sql = "Update UserRoles set RoleId='" + role + "' where UserId='" + user.UserId + "'";
                cmd = new System.Data.SqlClient.SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                closeconn();

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

        // GET: Users/Edit/5
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
        public async Task<ActionResult> ResetPassword([Bind(Include = "UserId,Username,Email,Password,ConfirmPassword,FirstName,LastName,IsActive,LockCount,CreateDate,role,BrokerName,BrokerCode")] User user)
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
                if (user.BrokerName == null)
                {
                    user.BrokerCode = "MORCO";
                    user.BrokerName = "Dry Associates";
                }
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

        // GET: Users/Delete/5
        public async Task<ActionResult> Delete(int? id)
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

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            string name2 = WebSecurity.CurrentUserName;
            var user2 = db.Users.ToList().Where(a => a.Email == name2);
            ViewBag.Users = "";
            foreach (var row in user2)
            {
                ViewBag.Users = row.FirstName + " " + row.LastName;
            }
            var name = db.Users.ToList().Where(a => a.Email == WebSecurity.CurrentUserName);
            string username = "";
            foreach (var p in name)
            {
                username = p.Username;
            }
            User user = await db.Users.FindAsync(id);
            db.Users.Remove(user);
            await db.SaveChangesAsync(username);
            System.Web.HttpContext.Current.Session["NOT"] = "You have successfully deleted the user";

            return RedirectToAction("Index");
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
