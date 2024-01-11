using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CTY_DVVT.Models;
using CTY_DVVT.Filters;

namespace CTY_DVVT.Controllers
{
    [AdminAuthorization]
    public class XeController : Controller
    {
        // GET: TaiXe
        public ActionResult Index()
        {
            DVVTDBContext db = new DVVTDBContext();
            List<Xe> lstXe = db.xes.ToList();
            return View(lstXe);
        }

        public ActionResult Create()
        {
            DVVTDBContext db = new DVVTDBContext();
            List<LoaiXe> lstLX = db.loaiXes.ToList();
            ViewBag.LX = lstLX;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Xe xe)
        {
            DVVTDBContext db = new DVVTDBContext();
            if (ModelState.IsValid)
            {
                db.xes.Add(xe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Create");
        }

        public ActionResult Edit(int id)
        {
            DVVTDBContext db = new DVVTDBContext();
            Xe xe = db.xes.Where(row => row.XeId == id).FirstOrDefault();
            List<LoaiXe> lstLX = db.loaiXes.ToList();
            ViewBag.LX = lstLX;
            return View(xe);
        }

        [HttpPost]
        public ActionResult Edit(Xe xe)
        {
            DVVTDBContext db = new DVVTDBContext();
            Xe xeup = db.xes.Where(row => row.XeId == xe.XeId).FirstOrDefault();
            xeup.LXID = xe.LXID;
            xeup.BSXe = xe.BSXe;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            DVVTDBContext db = new DVVTDBContext();
            List<LoaiXe> lstLX = db.loaiXes.ToList();
            ViewBag.LX = lstLX;
            Xe xe = db.xes.Where(row => row.XeId == id).FirstOrDefault();
            return View(xe);
        }

        [HttpPost]
        public ActionResult Delete(int id, Xe xe)
        {
            DVVTDBContext db = new DVVTDBContext();
            Xe xedel = db.xes.Where(row => row.XeId == id).FirstOrDefault();
            db.xes.Remove(xedel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}