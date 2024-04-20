using codefirst_lehabinh.data_access;
using codefirst_lehabinh.Models;
using Microsoft.AspNetCore.Mvc;

namespace codefirst_lehabinh.Controllers
{
    public class SinhVienController : Controller
    {
        private readonly sinhvien_DbContext _context;

        public SinhVienController(sinhvien_DbContext context) 
        {
            this._context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var sinhviens = _context.SinhVien
                                    .Where(s => s.Tuoi >= 18 && s.Tuoi <= 20
                                                && s.Lop.Khoa.TenKhoa == "Cong nghe so")
                                    .ToList();
            List<SinhVienViewModel> sinhvienlist = new List<SinhVienViewModel>();

            if (sinhviens != null)
            {

                foreach (var sinhvien in sinhviens)
                {
                    string tenKhoa = string.Empty; // Mặc định là chuỗi rỗng

                    // Kiểm tra xem đối tượng Lop và Khoa có tồn tại không trước khi truy cập
                    if (sinhvien.Lop != null && sinhvien.Lop.Khoa != null)
                    {
                        tenKhoa = sinhvien.Lop.Khoa.TenKhoa; // Truy cập tên khoa
                    }

                    var SinhvienViewModel = new SinhVienViewModel()
                    {
                        SinhVienId = sinhvien.SinhVienId,
                        Ten = sinhvien.Ten,
                        Tuoi = sinhvien.Tuoi,
                        LopId = sinhvien.LopId,
                        TenKhoa = tenKhoa,
                    };
                    sinhvienlist.Add(SinhvienViewModel);
                }
                return View(sinhvienlist);
            }
            return View(sinhvienlist);
        }

    }
}
