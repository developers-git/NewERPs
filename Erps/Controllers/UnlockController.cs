using Erps.DAO;
using Erps.DAO.security;
using Erps.Models;
using PagedList;
using System;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;

using System.Web.Mvc;
using WebMatrix.WebData;

namespace Erps.Controllers
{
    //[CustomAuthorize(RolesConfigKey = "RolesConfigKey")]
    // [CustomAuthorize(UsersConfigKey = "UsersConfigKey")]
    [CustomAuthorize(Roles = "Admin,Approver,BrokerAdmin", NotifyUrl = "/UnauthorizedPage")]
    // [CustomAuthorize(Users = "1")]

    public class UnlockController : Controller
    {
        private SBoardContext db = new SBoardContext();
        // GET: Unlock
        public ActionResult Index(string sortOrder, int? page)
        {
            var users = db.Users.ToList().Where(a => a.LockCount != 0);
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
            ///return View(users.ToList());
        }

        // GET: Users/Delete/5
        public ActionResult Unlocker(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Unlocker")]
        [ValidateAntiForgeryToken]
        public ActionResult UnlockerConfirmed(int id)
        {
            var name = db.Users.ToList().Where(b => b.Email == WebSecurity.CurrentUserName);
            string username = "";
            foreach (var p in name)
            {
                username = p.Username;
            }
            var a = db.Users.Find(id);
            a.LockCount = 0;
            db.Users.AddOrUpdate(a);
            db.SaveChanges(username);
            System.Web.HttpContext.Current.Session["NOT"] = "You have successfully unlocked the account";

            return RedirectToAction("Index");
        }
    }
}