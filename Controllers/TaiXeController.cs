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
    public class TaiXeController : Controller
    {
        // GET: TaiXe
        public ActionResult Index()
        {
            DVVTDBContext db = new DVVTDBContext();
            List<TaiXe> lstTX = db.taiXes.ToList();
            return View(lstTX);
        }

        public ActionResult Create()
        {
            DVVTDBContext db = new DVVTDBContext();
            List<Xe> lstXe = db.xes.ToList();
            ViewBag.Xe = lstXe;
            return View();
        }

        [HttpPost]
        public ActionResult Create(TaiXe tx)
        {
            DVVTDBContext db = new DVVTDBContext();
            if (ModelState.IsValid)
            {
                db.taiXes.Add(tx);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Create");
        }

        public ActionResult Edit(int id)
        {
            DVVTDBContext db = new DVVTDBContext();
            TaiXe kh = db.taiXes.Where(row => row.TXId == id).FirstOrDefault();
            List<Xe> lstXe = db.xes.ToList();
            ViewBag.Xe = lstXe;
            return View(kh);
        }

        [HttpPost]
        public ActionResult Edit(TaiXe taiXe)
        {
            DVVTDBContext db = new DVVTDBContext();
            TaiXe tx = db.taiXes.Where(row => row.TXId == taiXe.TXId).FirstOrDefault();
            tx.TXName = taiXe.TXName;
            tx.TXSdt = taiXe.TXSdt;
            tx.XeId = taiXe.XeId;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            DVVTDBContext db = new DVVTDBContext();
            TaiXe tx = db.taiXes.Where(row => row.TXId == id).FirstOrDefault();
            return View(tx);
        }

        [HttpPost]
        public ActionResult Delete(int id, TaiXe tx)
        {
            DVVTDBContext db = new DVVTDBContext();
            TaiXe taiXe = db.taiXes.Where(row => row.TXId == id).FirstOrDefault();
            db.taiXes.Remove(taiXe);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}