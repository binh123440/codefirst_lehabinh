using codefirst_lehabinh.data_access;
using codefirst_lehabinh.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace codefirst_lehabinh.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        //private readonly sinhvien_DbContext _context;



       /* public ViewResult DisplaySinhVienInfo()
        {
            var sinhVienCNTT = _context.SinhVien
                .Include(sv => sv.Lop)
                .ThenInclude(l => l.Khoa)
                .Where(sv => sv.Tuoi >= 18 && sv.Tuoi <= 20)
                .Select(sv => new SinhVienViewModel
                {
                    Ten = sv.Ten,
                    Tuoi = sv.Tuoi,
                    TenKhoa = sv.Lop.Khoa.TenKhoa
                })
                .ToList();

            return View(sinhVienCNTT);
        }*/

    }
}
