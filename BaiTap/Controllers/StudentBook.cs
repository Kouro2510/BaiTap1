using BaiTap.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BaiTap.Controllers
{
    public class StudentBook : Controller
    {
        private readonly ApplicationDbContext _context;
        private bool SinhVienSachIsExits(int id)
        {
            return _context.SinhVienSach_tbl.Any(e => e.ID == id);
        }
        public StudentBook(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<SinhVienSach_tbl> ListSinhVienSach = _context.SinhVienSach_tbl
                .Include(sv => sv.SinhVien_tbl) // Include related Sach entity
                .Include(sv => sv.Sach_tbl) // Include related SinhVien entity
                .ToList();
            return View(ListSinhVienSach);
        }

        // Thêm SinhVienSach
        public async Task<IActionResult> ThemSinhVienMuonSach(SinhVienSach_tbl sinhVienSach)
        {
            var validSinhVienIds = _context.SinhVien_tbl.Select(sv => sv.ID).ToList();
            if (!validSinhVienIds.Contains(sinhVienSach.IDSinhVien))
            {
                ViewBag.SachList = new SelectList(_context.Sach_tbl.ToList(), "ID", "TenSach");
                ViewBag.SinhVienList = new SelectList(_context.SinhVien_tbl.ToList(), "ID", "TenSinhVien");
                return View(sinhVienSach);
            }
            ViewBag.SinhVienList = new SelectList(_context.SinhVien_tbl.ToList(), "ID", "TenSinhVien");
            ViewBag.SachList = new SelectList(_context.Sach_tbl.ToList(), "ID", "TenSach");
            _context.Add(sinhVienSach);
            try
            {
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to save to database. Error: {ex.Message}");
                return View(sinhVienSach);
            }
        }

        // Sửa SinhVienSach
        public async Task<IActionResult> SuaThongTin(int? id)
        {
            ViewBag.SinhVienList = new SelectList(_context.SinhVien_tbl.ToList(), "ID", "TenSinhVien");
            ViewBag.SachList = new SelectList(_context.Sach_tbl.ToList(), "ID", "TenSach");
            if (id == null)
            {
                return NotFound();
            }

            var sinhVienSach = await _context.SinhVienSach_tbl.FindAsync(id);
            if (sinhVienSach == null)
            {
                return NotFound();
            }
            return View(sinhVienSach);
        }

        [HttpPost]
        public async Task<IActionResult> SuaThongTin(int id, SinhVienSach_tbl sinhVienSach)
        {
            if (id != sinhVienSach.ID)
            {
                return NotFound();
            }
            var validSinhVienIds = _context.SinhVien_tbl.Select(sv => sv.ID).ToList();
            if (!validSinhVienIds.Contains(sinhVienSach.IDSinhVien))
            {
                ViewBag.SachList = new SelectList(_context.Sach_tbl.ToList(), "ID", "TenSach");
                ViewBag.SinhVienList = new SelectList(_context.SinhVien_tbl.ToList(), "ID", "TenSinhVien");
                return View(sinhVienSach);
            }
            ViewBag.SinhVienList = new SelectList(_context.SinhVien_tbl.ToList(), "ID", "TenSinhVien");
            ViewBag.SachList = new SelectList(_context.Sach_tbl.ToList(), "ID", "TenSach");
            _context.Update(sinhVienSach);
            try
            {
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to save to database. Error: {ex.Message}");
                return View(sinhVienSach);
            }
        }



        // Xóa SinhVienSach
        public async Task<IActionResult> XoaThongTin(int id)
        {
            var ThongTin = await _context.SinhVienSach_tbl.FindAsync(id);
            _context.SinhVienSach_tbl.Remove(ThongTin);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}