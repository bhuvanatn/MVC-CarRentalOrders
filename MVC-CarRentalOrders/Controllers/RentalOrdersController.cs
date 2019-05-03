using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_CarRentalOrders;

namespace MVC_CarRentalOrders.Controllers
{
    public class RentalOrdersController : Controller
    {
        private RentalCarsEntities db = new RentalCarsEntities();

        // GET: RentalOrders
        public ActionResult Index()
        {
            var rentalOrders = db.RentalOrders.Include(r => r.Car).Include(r => r.Customer).Include(r => r.Employee);
            return View(rentalOrders.ToList());
        }

        // GET: RentalOrders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RentalOrder rentalOrder = db.RentalOrders.Find(id);
            if (rentalOrder == null)
            {
                return HttpNotFound();
            }
            return View(rentalOrder);
        }

        // GET: RentalOrders/Create
        public ActionResult Create()
        {
            ViewBag.CarId = new SelectList(db.Cars, "Id", "Make");
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "DriverLicenseNo");
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "EmployeeNumber");
            return View();
        }

        // POST: RentalOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DateProcessed,EmployeeId,CustomerId,CarId,RentStartDate,RentEndDate,Days")] RentalOrder rentalOrder)
        {
            if (ModelState.IsValid)
            {
                db.RentalOrders.Add(rentalOrder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CarId = new SelectList(db.Cars, "Id", "Make", rentalOrder.CarId);
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "DriverLicenseNo", rentalOrder.CustomerId);
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "EmployeeNumber", rentalOrder.EmployeeId);
            return View(rentalOrder);
        }

        // GET: RentalOrders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RentalOrder rentalOrder = db.RentalOrders.Find(id);
            if (rentalOrder == null)
            {
                return HttpNotFound();
            }
            ViewBag.CarId = new SelectList(db.Cars, "Id", "Make", rentalOrder.CarId);
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "DriverLicenseNo", rentalOrder.CustomerId);
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "EmployeeNumber", rentalOrder.EmployeeId);
            return View(rentalOrder);
        }

        // POST: RentalOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DateProcessed,EmployeeId,CustomerId,CarId,RentStartDate,RentEndDate,Days")] RentalOrder rentalOrder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rentalOrder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CarId = new SelectList(db.Cars, "Id", "Make", rentalOrder.CarId);
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "DriverLicenseNo", rentalOrder.CustomerId);
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "EmployeeNumber", rentalOrder.EmployeeId);
            return View(rentalOrder);
        }

        // GET: RentalOrders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RentalOrder rentalOrder = db.RentalOrders.Find(id);
            if (rentalOrder == null)
            {
                return HttpNotFound();
            }
            return View(rentalOrder);
        }

        // POST: RentalOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RentalOrder rentalOrder = db.RentalOrders.Find(id);
            db.RentalOrders.Remove(rentalOrder);
            db.SaveChanges();
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
