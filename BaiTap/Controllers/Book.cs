using BaiTap.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Windows;
namespace BaiTap.Controllers
{
    public class Book : Controller
    {
        private readonly ApplicationDbContext _context;
        private bool SachIsExists(int id)
        {
            return _context.Sach_tbl.Any(e => e.ID == id);
        }
        public Book(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Sach_tbl> ListSach = _context.Sach_tbl.ToList();
            return View(ListSach);
        }
        public async Task<IActionResult> ThemSach(Sach_tbl sach)
        {

            if (ModelState.IsValid)
            {
                _context.Add(sach);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sach);
        }
        public async Task<IActionResult> SuaThongTinSach(int id)
        {
            var sach = await _context.Sach_tbl.FirstOrDefaultAsync(s => s.ID == id);
            if (sach == null)
            {
                return NotFound();
            }

            return View(sach);
        }
        [HttpPost]
        public async Task<IActionResult> SuaThongTinSach(int id, Sach_tbl sach)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sach);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SachIsExists(sach.ID))
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
            return View(sach);

        }
        public async Task<IActionResult> XoaSach(int id)
        {
            var Sach = await _context.Sach_tbl.FindAsync(id);
            _context.Sach_tbl.Remove(Sach);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
