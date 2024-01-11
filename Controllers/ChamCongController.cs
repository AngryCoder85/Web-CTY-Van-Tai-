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
    public class ChamCongController : Controller
    {
        // GET: ChamCong
        public ActionResult Index(int id, string DayS = "", string DayE = "")
        {
            DVVTDBContext db = new DVVTDBContext();
            List<ChamCong> lstCC = new List<ChamCong>();
            lstCC = db.chamCongs.OrderByDescending(row => row.NgayThang).Where(row => row.TXId == id).ToList();
            if (!string.IsNullOrEmpty(DayS))
            {
                DateTime day1 = DateTime.Parse(DayS);
                DateTime day2 = DateTime.Parse(DayE);
                lstCC = db.chamCongs.OrderByDescending(row => row.NgayThang).Where(row => row.TXId == id && row.NgayThang.CompareTo(day1) >= 0 && row.NgayThang.CompareTo(day2) <= 0).ToList();
            }
            else
            {
                db.chamCongs.OrderByDescending(row => row.NgayThang).Where(row => row.TXId == id).ToList();
            }
            TaiXe tx = db.taiXes.Where(row => row.TXId == id).FirstOrDefault();
            ViewBag.TenTX = tx.TXName;
            ViewBag.ID = id;
            this.Session["tentx"] = tx.TXName;
            this.Session["IDTX"] = tx.TXId;
            TempData["IDTX"] = tx.TXId;
            RedirectToAction("Create");
            this.Session["lstCC"] = lstCC;
            return View(lstCC);
        }

        public ActionResult Create()
        {
            DVVTDBContext db = new DVVTDBContext();
            List<TaiXe> lstTX = db.taiXes.ToList();
            ViewBag.TX = lstTX;
            ViewBag.IDTX = Convert.ToInt32(TempData["IDTX"]);
            return View();
        }

        [HttpPost]
        public ActionResult Create(ChamCong cc)
        {
            DVVTDBContext db = new DVVTDBContext();
            if (ModelState.IsValid)
            {
                db.chamCongs.Add(cc);
                db.SaveChanges();
                return RedirectToAction("Index", new { id = cc.TXId });
            }
            return RedirectToAction("Create");
        }

        public ActionResult Edit(int id)
        {
            DVVTDBContext db = new DVVTDBContext();
            ChamCong cc = db.chamCongs.Where(row => row.ChamCongID == id).FirstOrDefault();
            List<TaiXe> TXlst = db.taiXes.ToList();
            ViewBag.TX = TXlst;
            return View(cc);
        }

        [HttpPost]
        public ActionResult Edit(ChamCong ccupd)
        {
            DVVTDBContext db = new DVVTDBContext();
            ChamCong cc = db.chamCongs.Where(row => row.ChamCongID == ccupd.ChamCongID).FirstOrDefault();
            cc.NgayThang = ccupd.NgayThang;
            cc.TXId = ccupd.TXId;
            cc.Luong = ccupd.Luong;
            cc.GhiChu = ccupd.GhiChu;
            db.SaveChanges();
            return RedirectToAction("Index", new { id = ccupd.TXId });
        }

        public ActionResult Delete(int id)
        {
            DVVTDBContext db = new DVVTDBContext();
            ChamCong ccdel = db.chamCongs.Where(row => row.ChamCongID == id).FirstOrDefault();
            return View(ccdel);
        }

        [HttpPost]
        public ActionResult Delete(int id, ChamCong ccdel)
        {
            DVVTDBContext db = new DVVTDBContext();
            ChamCong cc = db.chamCongs.Where(row => row.ChamCongID == id).FirstOrDefault();
            long ghostid = (long)cc.TXId;
            db.chamCongs.Remove(cc);
            db.SaveChanges();
            return RedirectToAction("Index", new { id= ghostid});
        }
        public ActionResult ExportToExcel()
        {
            List<ChamCong> lstCC = (List<ChamCong>)this.Session["lstCC"];
            var result = (from cc in lstCC
                          select new
                          {
                              NgayThang = cc.NgayThang.ToString("dd/MM/yyyy"),
                              TaiXe = cc.TaiXe.TXName,
                              Luong = cc.Luong.ToString("#,##0"),
                              GhiChu = cc.GhiChu,
                          }).ToList();

            var gv = new GridView();
            gv.DataSource = result;
            gv.DataBind();
            Response.ClearContent();
            Response.AddHeader("content-disposition", string.Format("attachment;filename=LuongTX_{0}_{1}.xls", this.Session["tentx"], DateTime.Now));
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            Response.BinaryWrite(System.Text.Encoding.UTF8.GetPreamble());
            Response.ContentType = "application/excel";

            StringWriter strw = new StringWriter();
            HtmlTextWriter htmlTw = new HtmlTextWriter(strw);

            gv.HeaderRow.Cells[0].Text = "Ngày tháng";
            gv.HeaderRow.Cells[1].Text = "Tài xế";
            gv.HeaderRow.Cells[2].Text = "Lương";
            gv.HeaderRow.Cells[3].Text = "Ghi chú";


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
            return RedirectToAction("Index", new { id = this.Session["IDTX"] });
        }
    }
}