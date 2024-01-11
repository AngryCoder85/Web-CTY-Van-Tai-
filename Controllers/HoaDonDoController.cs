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
    public class HoaDonDoController : Controller
    {
        // GET: HoaDonDo
        public ActionResult Index(string DayS="", string DayE="")
        {
            DVVTDBContext db = new DVVTDBContext();
            List<HoaDonDo> lstHDD = db.hoaDonDos.OrderByDescending(row => row.NgayThang).ToList();
            if(DayS != "" && DayE != "")
            {
                DateTime day1 = DateTime.Parse(DayS);
                DateTime day2 = DateTime.Parse(DayE);
                lstHDD = db.hoaDonDos.OrderByDescending(row => row.NgayThang).Where(row => row.NgayThang.CompareTo(day1) >= 0 && row.NgayThang.CompareTo(day2) <= 0).ToList();
            }
            else
            {
                lstHDD = db.hoaDonDos.OrderByDescending(row => row.NgayThang).ToList();
            }
            TempData["lstHDD"] = lstHDD;
            RedirectToAction("ExportToExcel");
            return View(lstHDD);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(HoaDonDo hdd)
        {
            DVVTDBContext db = new DVVTDBContext();
            if (ModelState.IsValid)
            {
                db.hoaDonDos.Add(hdd);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Create");
        }

        public ActionResult Edit(int id)
        {
            DVVTDBContext db = new DVVTDBContext();
            HoaDonDo hdd = db.hoaDonDos.Where(row => row.HoaDonDoID == id).FirstOrDefault();
            return View(hdd);
        }

        [HttpPost]
        public ActionResult Edit(HoaDonDo hddupd)
        {
            DVVTDBContext db = new DVVTDBContext();
            HoaDonDo hdd = db.hoaDonDos.Where(row => row.HoaDonDoID == hddupd.HoaDonDoID).FirstOrDefault();
            hdd.NgayThang = hddupd.NgayThang;
            hdd.HDNhap = hddupd.HDNhap;
            hdd.HDXuat = hddupd.HDXuat;
            hdd.GhiChu = hddupd.GhiChu;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            DVVTDBContext db = new DVVTDBContext();
            HoaDonDo hdddel = db.hoaDonDos.Where(row => row.HoaDonDoID == id).FirstOrDefault();
            return View(hdddel);
        }

        [HttpPost]
        public ActionResult Delete(int id, HoaDonDo hdd)
        {
            DVVTDBContext db = new DVVTDBContext();
            HoaDonDo hdddel = db.hoaDonDos.Where(row => row.HoaDonDoID == id).FirstOrDefault();
            db.hoaDonDos.Remove(hdddel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ExportToExcel()
        {
            List<HoaDonDo> lstHDD = (List<HoaDonDo>)TempData["lstHDD"];
            var result = (from hdd in lstHDD
                          select new
                          {
                              NgayThang = hdd.NgayThang.ToString("dd/MM/yyyy"),
                              HDNhap = hdd.HDNhap.ToString("#,##0"),
                              HDXuat = hdd.HDXuat.ToString("#,##0"),
                              GhiChu = hdd.GhiChu,
                          }).ToList();
            
            var gv = new GridView();
            gv.DataSource = result;
            gv.DataBind();
            Response.ClearContent();
            Response.AddHeader("content-disposition", string.Format("attachment;filename=BaoCaoHDD_{0}.xls", DateTime.Now));
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            Response.BinaryWrite(System.Text.Encoding.UTF8.GetPreamble());
            Response.ContentType = "application/excel";

            StringWriter strw = new StringWriter();
            HtmlTextWriter htmlTw = new HtmlTextWriter(strw);

            gv.HeaderRow.Cells[0].Text = "Ngày tháng";
            gv.HeaderRow.Cells[1].Text = "Hóa đơn nhập";
            gv.HeaderRow.Cells[2].Text = "Hóa đơn xuất";
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
            return RedirectToAction("Index");
        }
    }
}