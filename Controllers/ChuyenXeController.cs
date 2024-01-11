using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CTY_DVVT.Models;
using CTY_DVVT.Filters;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace CTY_DVVT.Controllers
{
    [AdminAuthorization]
    public class ChuyenXeController : Controller
    {
        // GET: ChuyenXe
        public ActionResult Index(string search="", string DayS="", string DayE="", string tentx = "")
        {
            DVVTDBContext db = new DVVTDBContext();
            List<KhachHang> lstKH = db.khachHangs.ToList();
            ViewBag.KH = lstKH;
            List<TaiXe> lstTX = db.taiXes.ToList();
            ViewBag.TX = lstTX;
            List<ChuyenXe> lstCX = new List<ChuyenXe>();
            lstCX = db.ChuyenXes.OrderByDescending(row => row.NgayThang).ToList();
            if (!string.IsNullOrEmpty(search) && string.IsNullOrEmpty(tentx))
            {
                lstCX = db.ChuyenXes.OrderByDescending(row => row.NgayThang).Where(row => row.KhachHang.KHName.Contains(search)).ToList();
            }
            if (!string.IsNullOrEmpty(tentx) && string.IsNullOrEmpty(search))
            {
                lstCX = db.ChuyenXes.OrderByDescending(row => row.NgayThang).Where(row => row.TaiXe.TXName.Contains(tentx)).ToList();
            }
            if(!string.IsNullOrEmpty(search) && !string.IsNullOrEmpty(tentx))
            {
                lstCX = db.ChuyenXes.OrderByDescending(row => row.NgayThang).Where(row => row.KhachHang.KHName.Contains(search) && row.TaiXe.TXName.Contains(tentx)).ToList();
            }
            if (DayS != "")
            {
                DateTime day1 = DateTime.Parse(DayS);
                DateTime day2 = DateTime.Parse(DayE);
                lstCX = lstCX.OrderByDescending(row => row.NgayThang).Where(row => row.NgayThang.CompareTo(day1) >= 0 && row.NgayThang.CompareTo(day2) <= 0 && row.KhachHang.KHName.Contains(search)).ToList();
            }
            TempData["lstCX"] = lstCX;
            RedirectToAction("ExportToExcel");
            return View(lstCX);
        }

        public ActionResult Create()
        {
            DVVTDBContext db = new DVVTDBContext();
            List<KhachHang> lstKH = db.khachHangs.ToList();
            ViewBag.KH = lstKH;
            List<TaiXe> lstTX = db.taiXes.ToList();
            ViewBag.TX = lstTX;
            return View();
        }

        [HttpPost]
        public ActionResult Create(ChuyenXe cx)
        {
            DVVTDBContext db = new DVVTDBContext();
            if (ModelState.IsValid)
            {
                db.ChuyenXes.Add(cx);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Create");
        }

        public ActionResult Edit(int id)
        {
            DVVTDBContext db = new DVVTDBContext();
            ChuyenXe cx = db.ChuyenXes.Where(row => row.CXID == id).FirstOrDefault();
            List<KhachHang> KHlst = db.khachHangs.ToList();
            ViewBag.KH = KHlst;
            List<TaiXe> lstTX = db.taiXes.ToList();
            ViewBag.TX = lstTX;
            return View(cx);
        }

        [HttpPost]
        public ActionResult Edit(ChuyenXe cxUpd)
        {
            DVVTDBContext db = new DVVTDBContext();
            ChuyenXe cx = db.ChuyenXes.Where(row => row.CXID == cxUpd.CXID).FirstOrDefault();
            cx.KHId = cxUpd.KHId;
            cx.TXId = cxUpd.TXId;
            cx.NgayThang = cxUpd.NgayThang;
            cx.SangChieu = cxUpd.SangChieu;
            cx.NoiNhanHang = cxUpd.NoiNhanHang;
            cx.NoiTraHang = cxUpd.NoiTraHang;
            cx.SanPham = cxUpd.SanPham;
            cx.KhoiLuongHH = cxUpd.KhoiLuongHH;
            cx.DonGia = cxUpd.DonGia;
            cx.ThanhTien = cxUpd.ThanhTien;
            cx.TienConLaiCT = cxUpd.TienConLaiCT;
            //cx.TienConLai = cxUpd.TienConLai; //Khi xoá tiền còn lại chuyến này, thì xoá luôn cái này
            cx.TienCamDi = cxUpd.TienCamDi;
            cx.TienSuaXe = cxUpd.TienSuaXe;
            cx.GhiChuSX = cxUpd.GhiChuSX;
            cx.TienDoDau = cxUpd.TienDoDau;
            cx.PhiCD = cxUpd.PhiCD;
            cx.TienCA = cxUpd.TienCA;
            cx.TienAn = cxUpd.TienAn;
            cx.TienThuocNuoc = cxUpd.TienThuocNuoc;
            cx.BoiDuong = cxUpd.BoiDuong;
            cx.LamHang = cxUpd.LamHang;
            cx.DenNuoc = cxUpd.DenNuoc;
            cx.PhatSinhThem = cxUpd.PhatSinhThem;
            cx.Thu = cxUpd.Thu;
            cx.Chi = cxUpd.Chi;
            cx.Tong = cxUpd.Tong;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            DVVTDBContext db = new DVVTDBContext();
            ChuyenXe cxdel = db.ChuyenXes.Where(row => row.CXID == id).FirstOrDefault();
            return View(cxdel);
        }

        [HttpPost]
        public ActionResult Delete(int id, ChuyenXe cx)
        {
            DVVTDBContext db = new DVVTDBContext();
            ChuyenXe cxdel = db.ChuyenXes.Where(row => row.CXID == id).FirstOrDefault();
            db.ChuyenXes.Remove(cxdel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //public ActionResult DeleteWithCond(string delname="")
        //{
        //    DVVTDBContext db = new DVVTDBContext();
        //    List<KhachHang> lstKH = db.khachHangs.ToList();
        //    ViewBag.KH = lstKH;
        //    if (delname == "delall")
        //    {
        //        db.ChuyenXes.RemoveRange(db.ChuyenXes.ToList());
        //        db.SaveChanges();
        //    }
        //    return RedirectToAction("Index");
        //}

        public ActionResult ExportToExcel()
        {
            List<ChuyenXe> lstCX = (List<ChuyenXe>)TempData["lstCX"];
            var result = (from cx in lstCX
                          select new
                          {
                              NgayThang = cx.NgayThang.ToString("dd/MM/yyyy"),
                              SangChieu = cx.SangChieu,
                              TaiXe = cx.TaiXe.TXName,
                              KhachHang = cx.KhachHang.KHName,
                              NoiNhanHang = cx.NoiNhanHang,
                              NoiTraHang = cx.NoiTraHang,
                              SanPham = cx.SanPham,
                              DonGia = cx.DonGia.ToString("#,##0"),
                              KhoiLuong = cx.KhoiLuongHH,
                              ThanhTien = cx.ThanhTien.ToString("#,##0"),
                              TienConLaiCT = cx.TienConLaiCT.ToString("#,##0"),
                              TienCamDi = cx.TienCamDi.ToString("#,##0"),
                              TienSuaXe = cx.TienSuaXe.ToString("#,##0"),
                              GhiChuSX = cx.GhiChuSX,
                              TienDoDau = cx.TienDoDau.ToString("#,##0"),
                              PhiCD = cx.PhiCD.ToString("#,##0"),
                              TienCA = cx.TienCA.ToString("#,##0"),
                              TienAn = cx.TienAn.ToString("#,##0"),
                              TienThuocNuoc = cx.TienThuocNuoc.ToString("#,##0"),
                              BoiDuong = cx.BoiDuong.ToString("#,##0"),
                              LamHang = cx.LamHang.ToString("#,##0"),
                              DenNuoc = cx.DenNuoc.ToString("#,##0"),
                              PhatSinhThem = cx.PhatSinhThem.ToString("#,##0"),
                              Thu = cx.Thu.ToString("#,##0"),
                              Chi = cx.Chi.ToString("#,##0"),
                              Tong = cx.Tong.ToString("#,##0"),
                          }).ToList();
            var gv = new GridView();
            gv.DataSource = result;
            gv.DataBind();
            Response.ClearContent();
            Response.AddHeader("content-disposition", string.Format("attachment;filename=BaoCao_{0}.xls", DateTime.Now));
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            Response.BinaryWrite(System.Text.Encoding.UTF8.GetPreamble());
            Response.ContentType = "application/excel";

            StringWriter strw = new StringWriter();
            HtmlTextWriter htmlTw = new HtmlTextWriter(strw);

            gv.HeaderRow.Cells[0].Text = "Ngày tháng";
            gv.HeaderRow.Cells[1].Text = "Sáng / Chiều";
            gv.HeaderRow.Cells[2].Text = "Tài xế";
            gv.HeaderRow.Cells[3].Text = "Khách hàng";
            gv.HeaderRow.Cells[4].Text = "Nơi nhận hàng";
            gv.HeaderRow.Cells[5].Text = "Nơi trả hàng";
            gv.HeaderRow.Cells[6].Text = "Sản phẩm";
            gv.HeaderRow.Cells[7].Text = "Đơn giá";
            gv.HeaderRow.Cells[8].Text = "Khối lượng (Tấn)";
            gv.HeaderRow.Cells[9].Text = "Lấy tiền / Chuyển khoản";
            gv.HeaderRow.Cells[10].Text = "Tiền còn lại chuyến trước";
            gv.HeaderRow.Cells[11].Text = "Tiền cầm đi";
            gv.HeaderRow.Cells[12].Text = "Tiền sửa xe";
            gv.HeaderRow.Cells[13].Text = "Ghi chú sửa xe";
            gv.HeaderRow.Cells[14].Text = "Tiền đổ dầu";
            gv.HeaderRow.Cells[15].Text = "Phí cầu đường";
            gv.HeaderRow.Cells[16].Text = "Tiền CA";
            gv.HeaderRow.Cells[17].Text = "Tiền ăn";
            gv.HeaderRow.Cells[18].Text = "Tiền thuốc nước";
            gv.HeaderRow.Cells[19].Text = "Bồi dưỡng";
            gv.HeaderRow.Cells[20].Text = "Làm hàng";
            gv.HeaderRow.Cells[21].Text = "Đền nước";
            gv.HeaderRow.Cells[22].Text = "Phát sinh thêm";
            //gv.HeaderRow.Cells[23].Text = "Tiền còn lại chuyến này";
            gv.HeaderRow.Cells[23].Text = "Thu";
            gv.HeaderRow.Cells[24].Text = "Chi";
            gv.HeaderRow.Cells[25].Text = "Tổng";

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