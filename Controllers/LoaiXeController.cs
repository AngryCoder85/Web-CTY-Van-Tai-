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
    public class LoaiXeController : Controller
    {
        // GET: TaiXe
        public ActionResult Index()
        {
            DVVTDBContext db = new DVVTDBContext();
            List<LoaiXe> lstLX = db.loaiXes.ToList();
            return View(lstLX);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(LoaiXe xe)
        {
            DVVTDBContext db = new DVVTDBContext();
            if (ModelState.IsValid)
            {
                db.loaiXes.Add(xe);
                db.SaveChanges();
                return RedirectToAction("Index", "Xe");
            }
            return RedirectToAction("Create");
        }

        public ActionResult Edit(int id)
        {
            DVVTDBContext db = new DVVTDBContext();
            LoaiXe xe = db.loaiXes.Where(row => row.LXID == id).FirstOrDefault();
            return View(xe);
        }

        [HttpPost]
        public ActionResult Edit(LoaiXe xe)
        {
            DVVTDBContext db = new DVVTDBContext();
            LoaiXe xeup = db.loaiXes.Where(row => row.LXID == xe.LXID).FirstOrDefault();
            xeup.LXName = xe.LXName;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            DVVTDBContext db = new DVVTDBContext();
            LoaiXe xe = db.loaiXes.Where(row => row.LXID == id).FirstOrDefault();
            return View(xe);
        }

        [HttpPost]
        public ActionResult Delete(int id, LoaiXe xe)
        {
            DVVTDBContext db = new DVVTDBContext();
            LoaiXe xedel = db.loaiXes.Where(row => row.LXID == id).FirstOrDefault();
            db.loaiXes.Remove(xedel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}