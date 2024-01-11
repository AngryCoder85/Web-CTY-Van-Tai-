using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CTY_DVVT.Models;
using CTY_DVVT.Filters;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CTY_DVVT.Controllers
{
    [AdminAuthorization]
    public class BaoCaoXeController : Controller
    {
        // GET: ChamCong
        public ActionResult Index(int id, string DayS="", string DayE = "")
        {
            DVVTDBContext db = new DVVTDBContext();
            List<BaoCaoXe> lstBCX = new List<BaoCaoXe>();
            lstBCX = db.BaoCaoXes.OrderByDescending(row => row.NgayThang).Where(row => row.XeId == id).ToList();
            if (!string.IsNullOrEmpty(DayS))
            {
                DateTime day1 = DateTime.Parse(DayS);
                DateTime day2 = DateTime.Parse(DayE);
                lstBCX = lstBCX.Where(row => row.NgayThang.CompareTo(day1) >= 0 && row.NgayThang.CompareTo(day2) <= 0).ToList();
            }
            else
            {
                lstBCX = db.BaoCaoXes.OrderByDescending(row => row.NgayThang).Where(row => row.XeId == id).ToList();
            }
            Xe xe = db.xes.Where(row => row.XeId == id).FirstOrDefault();
            ViewBag.LX = xe.LoaiXe.LXName;
            ViewBag.BSXe = xe.BSXe;
            ViewBag.ID = id;
            this.Session["BSXe"] = xe.BSXe;
            this.Session["XEID"] = xe.XeId;
            TempData["IDXe"] = xe.XeId;
            RedirectToAction("Create");
            this.Session["lstBCX"] = lstBCX;
            return View(lstBCX);
        }

        public ActionResult Create()
        {
            DVVTDBContext db = new DVVTDBContext();
            List<Xe> lstXe = db.xes.ToList();
            ViewBag.Xe = lstXe;
            ViewBag.XeID = Convert.ToInt32(TempData["IDXe"]);
            return View();
        }

        [HttpPost]
        public ActionResult Create(BaoCaoXe bcx)
        {
            DVVTDBContext db = new DVVTDBContext();
            if (ModelState.IsValid)
            {
                db.BaoCaoXes.Add(bcx);
                db.SaveChanges();
                return RedirectToAction("Index", new { id = bcx.XeId });
            }
            return RedirectToAction("Create");
        }

        public ActionResult Edit(int id)
        {
            DVVTDBContext db = new DVVTDBContext();
            BaoCaoXe bcx = db.BaoCaoXes.Where(row => row.BCXId == id).FirstOrDefault();
            List<Xe> lstXe = db.xes.ToList();
            ViewBag.Xe = lstXe;
            return View(bcx);
        }

        [HttpPost]
        public ActionResult Edit(BaoCaoXe bcx)
        {
            DVVTDBContext db = new DVVTDBContext();
            BaoCaoXe bcxup = db.BaoCaoXes.Where(row => row.BCXId == bcx.BCXId).FirstOrDefault();
            bcxup.NgayThang = bcx.NgayThang;
            bcxup.XeId = bcx.XeId;
            bcxup.Tien = bcx.Tien;
            bcxup.GhiChu = bcx.GhiChu;
            db.SaveChanges();
            return RedirectToAction("Index", new { id = bcxup.XeId });
        }

        public ActionResult Delete(int id)
        {
            DVVTDBContext db = new DVVTDBContext();
            BaoCaoXe bcxdel = db.BaoCaoXes.Where(row => row.BCXId == id).FirstOrDefault();
            return View(bcxdel);
        }

        [HttpPost]
        public ActionResult Delete(int id, BaoCaoXe bcx)
        {
            DVVTDBContext db = new DVVTDBContext();
            BaoCaoXe bcxdel = db.BaoCaoXes.Where(row => row.BCXId == id).FirstOrDefault();
            long ghostid = (long)bcxdel.XeId;
            db.BaoCaoXes.Remove(bcxdel);
            db.SaveChanges();
            return RedirectToAction("Index", new { id = ghostid });
        }
        public ActionResult ExportToExcel()
        {
            List<BaoCaoXe> lstBCX = (List<BaoCaoXe>)this.Session["lstBCX"];
            var result = (from bcx in lstBCX
                          select new
                          {
                              NgayThang = bcx.NgayThang.ToString("dd/MM/yyyy"),
                              Xe = bcx.Xe.LoaiXe.LXName,
                              BSXe = bcx.Xe.BSXe,
                              Tien = bcx.Tien.ToString("#,##0"),
                              GhiChu = bcx.GhiChu,
                          }).ToList();

            var gv = new GridView();
            gv.DataSource = result;
            gv.DataBind();
            Response.ClearContent();
            Response.AddHeader("content-disposition", string.Format("attachment;filename=BaoCaoXe_{0}_{1}.xls", this.Session["BSXe"], DateTime.Now));
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            Response.BinaryWrite(System.Text.Encoding.UTF8.GetPreamble());
            Response.ContentType = "application/excel";

            StringWriter strw = new StringWriter();
            HtmlTextWriter htmlTw = new HtmlTextWriter(strw);

            gv.HeaderRow.Cells[0].Text = "Ngày tháng";
            gv.HeaderRow.Cells[1].Text = "Loại xe";
            gv.HeaderRow.Cells[2].Text = "Biển số xe";
            gv.HeaderRow.Cells[3].Text = "Tiền";
            gv.HeaderRow.Cells[4].Text = "Báo cáo";


            foreach (GridViewRow row in gv.Rows)
            {
                foreach (TableCell cell in row.Cells)
                {
                    cell.Attributes.CssStyle["text-align"] = "center";
                }
            }

            gv.RenderControl(htmlTw);
            Response.Write(strw.ToString());
            Response.End();
            return RedirectToAction("Index", new { id = this.Session["XEID"] });
        }
    }
}