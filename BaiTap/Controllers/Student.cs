using BaiTap.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Windows;
namespace BaiTap.Controllers
{
    public class Student : Controller
    {
        private readonly ApplicationDbContext _context;
        private bool SinhVienIsExists(int id)
        {
            return _context.SinhVien_tbl.Any(e => e.ID == id);
        }
        public Student(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<SinhVien_tbl> ListSinhVien = _context.SinhVien_tbl.ToList();
            return View(ListSinhVien);
        }
        public async Task<IActionResult> ThemSinhVien(SinhVien_tbl sinhVien)
        {

            if(ModelState.IsValid)
            {
                _context.Add(sinhVien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sinhVien);
        }
        public async Task<IActionResult> SuaSinhVien(int id)
        {
            var sinhVien = await _context.SinhVien_tbl.FirstOrDefaultAsync(s => s.ID == id);
            if (sinhVien == null)
            {
                return NotFound();
            }

            return View(sinhVien);
        }
        [HttpPost]
        public async Task<IActionResult> SuaSinhVien(int id,SinhVien_tbl sinhVien)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sinhVien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SinhVienIsExists(sinhVien.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(sinhVien);

        }
        public async Task<IActionResult> XoaSinhVien(int id)
        {
            var sinhvien = await _context.SinhVien_tbl.FindAsync(id);
            _context.SinhVien_tbl.Remove(sinhvien);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
