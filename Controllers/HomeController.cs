using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CTY_DVVT.Models;

namespace CTY_DVVT.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            List<DichVu> dvs = new List<DichVu>()
            {
                new DichVu() {DVName = "Dịch Vụ Dọn Nhà, Kho", DVDescription = "Chuyển nhà trọn gói, di dời, chuyển kho xưởng, nhà máy", DVUrlImg = "bi bi-boxes"},
                new DichVu() {DVName = "Dịch Vụ Bốc Xếp", DVDescription = "Bốc vào kho, bốc lên lầu", DVUrlImg = "bi bi-box2-fill"},
                new DichVu() {DVName = "Dịch Vụ Nâng Cẩu", DVDescription = "Nâng cẩu máy móc, thiết bị nặng từ 500kg đến 40 tấn", DVUrlImg = "bi bi-truck-flatbed"}
            };

            List<DichVu> dvvt = new List<DichVu>()
            {
                new DichVu() {DVName = "Vận Chuyển Hàng Lẻ", DVDescription = "Xe đi trong ngày, Không mất thời gian chờ ghép hàng, Xe giao hàng tận nơi, giá cước vận tải Siêu Rẻ", DVUrlImg = "vc-hl.jpeg"},
                new DichVu() {DVName = "Vận Tải Bắc Nam", DVDescription = "Xe chạy 9 chuyến mỗi ngày, vận chuyển hàng hai chiều, dịch vụ vận tải giá rẻ nhất, Giao hàng tận nơi Miễn Phí", DVUrlImg = "vt-bn.jpeg"},
                new DichVu() {DVName = "Cho Thuê Xe Tải", DVDescription = "Cho thuê xe tải tự lái và cho thuê xe tải theo tháng, cho thuê xe chở hàng theo chuyến. Các loại xe tải từ 1 tân đến 30 tấn.", DVUrlImg = "ct-xt.jpg"},
                new DichVu() {DVName = "Vận Chuyển Hàng Container", DVDescription = "Vận chuyển và kéo Container đường bộ và dịch vụ vận chuyển Container đường biển. Giao hàng door to door.", DVUrlImg = "vch-cont.jpeg"},
                new DichVu() {DVName = "Vận Chuyển Máy Cơ Giới", DVDescription = "Vận chuyển máy đào, vận chuyển máy xúc, và cá máy phục vụ công trình xây dựng bằng xe Rờ mooc lùn chuyên dụng.", DVUrlImg = "vch-may.jpeg"},
                new DichVu() {DVName = "Vận Chuyển Hàng Quá Khổ", DVDescription = "Vận chuyển hàng siêu trường siêu trọng, vận tải hàng quá khổ, quá tải. Cung cấp dịch nâng hạ trọn gói.", DVUrlImg = "vc-hqk.jpeg"}
            };

            List<DichVu> tcvt = new List<DichVu>()
            {
                new DichVu() {DVName = "Giao Hàng Đúng Hẹn", DVDescription = "Giao hàng chính xác theo giờ, thông báo lịch xe đến từ 2-4h.", DVUrlImg = "bi bi-clock"},
                new DichVu() {DVName = "Giá Cước Luôn Siêu Rẻ", DVDescription = "Giá cước vận tải luôn thấp hơn thị trường 10% -15%. Chính sách giá ổn định.", DVUrlImg = "bi bi-coin"},
                new DichVu() {DVName = "An Toàn Là Trên Hết", DVDescription = "Hệ thống phương tiện vận tải đời mới, luôn lấy an toàn hàng hóa làm gốc.", DVUrlImg = "bi bi-record-circle"},
                new DichVu() {DVName = "Dịch Vụ Tận Tâm", DVDescription = "Giao hàng luôn tận tâm và tận tình trong dịch vụ vận tải chúng tôi.", DVUrlImg = "bi bi-award-fill"},
                new DichVu() {DVName = "Đền Bù Thỏa Đáng", DVDescription = "Đền bù thỏa đáng theo đúng hợp đồng vận tải đã ký kết.", DVUrlImg = "bi bi-cash-coin"},
                new DichVu() {DVName = "Bảo Mật Thông Tin", DVDescription = "Bảo mật thông tin tuyệt đối cho khánh hàng mọi lúc mọi nơi.", DVUrlImg = "bi bi-incognito"}
            };

            List<DichVu> ptvc = new List<DichVu>()
            {
                new DichVu() {DVName = "Xe Vận Tải 8 - 15 Tấn", DVDescription = "Thùng xe dài từ 7,5m đến 10m, có thể vận chuyển hàng đến cả nước", DVUrlImg = "xt8-15.jpeg"},
                new DichVu() {DVName = "Xe Container Mui Kín", DVDescription = "Container 40'= 12m, Container 45'= 13.8m, Container 50' = 15m", DVUrlImg = "xc-mk.jpeg"},
                new DichVu() {DVName = "Xe Container Mui Bạt", DVDescription = "Thùng Container dài từ 12m đến 15,1m, có mui tháo dỡ di động", DVUrlImg = "xc-mb.jpeg"},
                new DichVu() {DVName = "Xe Rờ Mooc Lùn", DVDescription = "Chuyên dụng chở hàng máy móc cơ giới và hàng quá khổ", DVUrlImg = "xr-ml.jpeg"}
            };

            List<DichVu> dsch = new List<DichVu>()
            {
                new DichVu() {DVName = "Công ty vận tải nào giá rẻ nhất?", DVDescription = "Bạn hãy thử khảo sát giá các công ty vận tải trên thị trường. Và đáp án chắc chắn sẽ là vận tải Biển Đông.", DVUrlImg = "cau1"},
                new DichVu() {DVName = "Công ty Vận Tải đền bao nhiêu tiền khi làm hư hàng?", DVDescription = "Nếu không may trong quá trình vận chuyển hàng hóa bị hư hỏng, Công ty sẽ chịu trách nhiệm đền bù theo đúng giá trị hàng hóa bị hư hao.", DVUrlImg = "cau2"}
            };

            List<DichVu> ds = new List<DichVu>()
            {
                new DichVu() {DVName = "#", DVDescription = "Giá dầu không phải là yếu tố duy nhất ảnh hưởng giá cước vận chuyển.", DVUrlImg = "#"},
                new DichVu() {DVName = "#", DVDescription = "Tuyến xa hơn nhưng giá cước vận tải có thể rẻ hơn.", DVUrlImg = "#"},
                new DichVu() {DVName = "#", DVDescription = "Xe tải trọng cao hơn không có nghĩa là thùng chứa hàng dài hơn, rộng hơn.", DVUrlImg = "#"},
                new DichVu() {DVName = "#", DVDescription = "Nếu chỉ làm hợp đồng để ràng buộc trách nhiệm vận chuyển là chưa đủ.", DVUrlImg = "#"},
                new DichVu() {DVName = "#", DVDescription = "Hợp đồng vận chuyển với công ty không rõ lai lịch cước tuy rẻ mà đắt.", DVUrlImg = "#"},
                new DichVu() {DVName = "#", DVDescription = "Không công ty vận tải nào chịu trách nhiệm về pháp lý hàng hóa.", DVUrlImg = "#"},
                new DichVu() {DVName = "#", DVDescription = "Làm việc qua tin nhắn, hoặc zalo vẫn có giá trị pháp lý.", DVUrlImg = "#"},
                new DichVu() {DVName = "#", DVDescription = "Bảo hiểm hàng hóa chỉ giới hạn trách nhiệm đền bù theo khung nhất định.", DVUrlImg = "#"},
                new DichVu() {DVName = "#", DVDescription = "Công ty vận tải càng lớn thì càng uy tín.", DVUrlImg = "#"}
            };

            ViewBag.DVList = dvs;
            ViewBag.DVVCHList = dvvt;
            ViewBag.TCVTList = tcvt;
            ViewBag.PTVCList = ptvc;
            ViewBag.DSCH = dsch;
            ViewBag.DS = ds;
            return View();
        }
    }
}