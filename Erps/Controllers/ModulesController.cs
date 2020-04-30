using Erps.DAO;
using Erps.DAO.security;
using Erps.Models;
using PagedList;
using System;
using System.Collections.Generic;
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
    public class ModulesController : Controller
    {
        private SBoardContext db = new SBoardContext();

        // GET: Modules
        public async Task<ActionResult> Index(string sortOrder, int? page)
        {

            // var Modules = db.Modules.Include(m => m.Roles);
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.ModuleSortParm = String.IsNullOrEmpty(sortOrder) ? "module" : "";
            var per = from s in db.Modules.Include(m => m.Role)
                      select s;
            switch (sortOrder)
            {
                case "name_desc":
                    per = per.OrderBy(s => s.ModulesName);
                    break;



                default:
                    per = per.OrderBy(s => s.ModulesID);
                    break;
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(per.ToPagedList(pageNumber, pageSize));
        }

        // GET: Modules/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Module modules = await db.Modules.FindAsync(id);
            if (modules == null)
            {
                return HttpNotFound();
            }
            return View(modules);
        }

        // GET: Modules/Create
        public ActionResult Create()
        {
            ViewBag.RoleID = new SelectList(db.Roles, "RoleId", "RoleName");
            var list4 = db.glyphicons.ToList();
            //Create List of SelectListItem
            List<SelectListItem> selectlist4 = new List<SelectListItem>();
            selectlist4.Add(new SelectListItem() { Text = "", Value = "" });
            foreach (var row in list4)
            {
                //Adding every record to list  
                selectlist4.Add(new SelectListItem { Text = row.glyphiconname, Value = row.glyphiconname.ToString() });
            }
            ViewBag.Dlyp = selectlist4;
            return View();
        }

        // POST: Modules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ModulesID,ModulesName,RoleID,glyphicon,ControllerName,ViewName,Name,IsWebForm,webFormUrl,MenuRank")] Module modules)
        {
            var name = db.Users.ToList().Where(a => a.Email == WebSecurity.CurrentUserName);
            string username = "";
            foreach (var p in name)
            {
                username = p.Username;
            }
            if (ModelState.IsValid)
            {
                db.Modules.Add(modules);
                await db.SaveChangesAsync(username);
                System.Web.HttpContext.Current.Session["NOT"] = "You have successfully added the Module";

                return RedirectToAction("Index");
            }

            ViewBag.RoleID = new SelectList(db.Roles, "RoleId", "RoleName", modules.RoleID);
            var list4 = db.glyphicons.ToList();
            //Create List of SelectListItem
            List<SelectListItem> selectlist4 = new List<SelectListItem>();
            selectlist4.Add(new SelectListItem() { Text = "", Value = "" });
            foreach (var row in list4)
            {
                //Adding every record to list
                selectlist4.Add(new SelectListItem { Text = row.glyphiconname, Value = row.glyphiconname.ToString() });
            }
            ViewBag.Dlyp = selectlist4;
            return View(modules);
        }

        // GET: Modules/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Module modules = await db.Modules.FindAsync(id);
            if (modules == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoleID = new SelectList(db.Roles, "RoleId", "RoleName", modules.RoleID);
            var list4 = db.glyphicons.ToList();
            // Create List of SelectListItem
            List<SelectListItem> selectlist4 = new List<SelectListItem>();
            selectlist4.Add(new SelectListItem() { Text = "", Value = "" });
            foreach (var row in list4)
            {
                //Adding every record to list
                selectlist4.Add(new SelectListItem { Text = row.glyphiconname, Value = row.glyphiconname.ToString() });
            }
            ViewBag.Dlyp = selectlist4;
            return View(modules);
        }

        // POST: Modules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ModulesID,ModulesName,RoleID,glyphicon,ControllerName,ViewName,Name,IsWebForm,webFormUrl,MenuRank")] Module modules)
        {
            var name = db.Users.ToList().Where(a => a.Email == WebSecurity.CurrentUserName);
            string username = "";
            foreach (var p in name)
            {
                username = p.Username;
            }
            if (ModelState.IsValid)
            {
                db.Entry(modules).State = EntityState.Modified;
                await db.SaveChangesAsync(username);
                System.Web.HttpContext.Current.Session["NOT"] = "You have successfully updated the Module";

                return RedirectToAction("Index");
            }
            ViewBag.RoleID = new SelectList(db.Roles, "RoleId", "RoleName", modules.RoleID);
            var list4 = db.glyphicons.ToList();
            // Create List of SelectListItem
            List<SelectListItem> selectlist4 = new List<SelectListItem>();
            selectlist4.Add(new SelectListItem() { Text = "", Value = "" });
            foreach (var row in list4)
            {
                // Adding every record to list
                selectlist4.Add(new SelectListItem { Text = row.glyphiconname, Value = row.glyphiconname.ToString() });
            }
            ViewBag.Dlyp = selectlist4;
            return View(modules);
        }

        // GET: Modules/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Module modules = await db.Modules.FindAsync(id);
            if (modules == null)
            {
                return HttpNotFound();
            }
            return View(modules);
        }

        // POST: Modules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var name = db.Users.ToList().Where(a => a.Email == WebSecurity.CurrentUserName);
            string username = "";
            foreach (var p in name)
            {
                username = p.Username;
            }
            Module modules = await db.Modules.FindAsync(id);
            db.Modules.Remove(modules);
            await db.SaveChangesAsync(username);
            System.Web.HttpContext.Current.Session["NOT"] = "You have successfully deleted the Module";

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
