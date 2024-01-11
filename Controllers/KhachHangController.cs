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
    public class KhachHangController : Controller
    {
        // GET: KhachHang
        public ActionResult Index()
        {
            DVVTDBContext db = new DVVTDBContext();
            List<KhachHang> lstkh = db.khachHangs.ToList();
            return View(lstkh);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(KhachHang kh)
        {
            DVVTDBContext db = new DVVTDBContext();
            if(ModelState.IsValid)
            {
                db.khachHangs.Add(kh);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Create");
        }

        public ActionResult Edit(int id)
        {
            DVVTDBContext db = new DVVTDBContext();
            KhachHang kh = db.khachHangs.Where(row => row.KHId == id).FirstOrDefault();
            return View(kh);
        }

        [HttpPost]
        public ActionResult Edit(KhachHang kh)
        {
            DVVTDBContext db = new DVVTDBContext();
            KhachHang khachHang = db.khachHangs.Where(row => row.KHId == kh.KHId).FirstOrDefault();
            khachHang.KHName = kh.KHName;
            khachHang.KHSdt = kh.KHSdt;
            khachHang.KHDiaChi = kh.KHDiaChi;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            DVVTDBContext db = new DVVTDBContext();
            KhachHang kh = db.khachHangs.Where(row => row.KHId == id).FirstOrDefault();
            return View(kh);
        }

        [HttpPost]
        public ActionResult Delete(int id, KhachHang kh)
        {
            DVVTDBContext db = new DVVTDBContext();
            KhachHang khachHang = db.khachHangs.Where(row => row.KHId == id).FirstOrDefault();
            db.khachHangs.Remove(khachHang);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}