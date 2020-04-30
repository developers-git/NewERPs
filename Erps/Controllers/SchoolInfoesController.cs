using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Erps.DAO;
using Erps.Models;
using PagedList;

namespace Erps.Controllers
{
    public class SchoolInfoesController : Controller
    {
        private SBoardContext db = new SBoardContext();

        // GET: SchoolInfoes
        public async Task<ActionResult> Index(string sortOrder, int? page)
        {
            var schoolInfoes = db.SchoolInfoes.Include(s => s.SchoolType1);
            switch (sortOrder)
            {
                case "name_desc":
                    schoolInfoes = schoolInfoes.OrderByDescending(s => s.ContactNo);
                    break;

                case null:
                    schoolInfoes = schoolInfoes.OrderBy(s => s.SchoolName);
                    break;

                default:
                    schoolInfoes = schoolInfoes.OrderBy(s => s.SchoolName);
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(schoolInfoes.ToPagedList(pageNumber, pageSize));
            //return View(await schoolInfoes.ToListAsync());
        }

        // GET: SchoolInfoes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SchoolInfo schoolInfo = await db.SchoolInfoes.FindAsync(id);
            if (schoolInfo == null)
            {
                return HttpNotFound();
            }
            return View(schoolInfo);
        }

        // GET: SchoolInfoes/Create
        public ActionResult Create()
        {
            ViewBag.SchoolType = new SelectList(db.SchoolTypes, "Type", "Type");
            return View();
        }

        // POST: SchoolInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "S_Id,SchoolName,Address,ContactNo,AltContactNo,FaxNo,Email,Website,Logo,RegistrationNo,DiseNo,IndexNo,EstablishedYear,Class,SchoolType")] SchoolInfo schoolInfo)
        {
            if (ModelState.IsValid)
            {
                db.SchoolInfoes.Add(schoolInfo);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.SchoolType = new SelectList(db.SchoolTypes, "Type", "Type", schoolInfo.SchoolType);
            return View(schoolInfo);
        }

        // GET: SchoolInfoes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SchoolInfo schoolInfo = await db.SchoolInfoes.FindAsync(id);
            if (schoolInfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.SchoolType = new SelectList(db.SchoolTypes, "Type", "Type", schoolInfo.SchoolType);
            return View(schoolInfo);
        }

        // POST: SchoolInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "S_Id,SchoolName,Address,ContactNo,AltContactNo,FaxNo,Email,Website,Logo,RegistrationNo,DiseNo,IndexNo,EstablishedYear,Class,SchoolType")] SchoolInfo schoolInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(schoolInfo).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.SchoolType = new SelectList(db.SchoolTypes, "Type", "Type", schoolInfo.SchoolType);
            return View(schoolInfo);
        }

        // GET: SchoolInfoes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SchoolInfo schoolInfo = await db.SchoolInfoes.FindAsync(id);
            if (schoolInfo == null)
            {
                return HttpNotFound();
            }
            return View(schoolInfo);
        }

        // POST: SchoolInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SchoolInfo schoolInfo = await db.SchoolInfoes.FindAsync(id);
            db.SchoolInfoes.Remove(schoolInfo);
            await db.SaveChangesAsync();
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
