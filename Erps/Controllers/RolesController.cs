using Erps.DAO;
using Erps.DAO.security;
using Erps.Models;
using PagedList;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace Erps.Controllers
{ //[CustomAuthorize(RolesConfigKey = "RolesConfigKey")]
  // [CustomAuthorize(UsersConfigKey = "UsersConfigKey")]
    [CustomAuthorize(Roles = "Admin")]
    // [CustomAuthorize(Users = "1")]
    public class RolesController : Controller
    {
        private SBoardContext db = new SBoardContext();

        // GET: Roles
        public async Task<ActionResult> Index(string sortOrder, int? page)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            var per = from s in db.Roles
                      select s;
            switch (sortOrder)
            {
                case "name_desc":
                    per = per.OrderByDescending(s => s.RoleName);
                    break;

                default:
                    per = per.OrderBy(s => s.RoleId);
                    break;
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(per.ToPagedList(pageNumber, pageSize));
        }

        // GET: Roles/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Role role = await db.Roles.FindAsync(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        // GET: Roles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Roles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "RoleId,RoleName,Description")] Role role)
        {
            var name = db.Users.ToList().Where(a => a.Email == WebSecurity.CurrentUserName);
            string username = "";
            foreach (var p in name)
            {
                username = p.Username;
            }
            if (ModelState.IsValid)
            {
                db.Roles.Add(role);
                await db.SaveChangesAsync(username);
                System.Web.HttpContext.Current.Session["NOT"] = "You have successfully added the Role";

                return RedirectToAction("Index");
            }

            return View(role);
        }

        // GET: Roles/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Role role = await db.Roles.FindAsync(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        // POST: Roles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "RoleId,RoleName,Description")] Role role)
        {
            if (ModelState.IsValid)
            {
                db.Entry(role).State = EntityState.Modified;
                await db.SaveChangesAsync();
                System.Web.HttpContext.Current.Session["NOT"] = "You have successfully updated the Role";

                return RedirectToAction("Index");
            }
            return View(role);
        }

        // GET: Roles/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Role role = await db.Roles.FindAsync(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        // POST: Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Role role = await db.Roles.FindAsync(id);
            db.Roles.Remove(role);
            await db.SaveChangesAsync();
            System.Web.HttpContext.Current.Session["NOT"] = "You have successfully deleted the Role";

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
    }
}
