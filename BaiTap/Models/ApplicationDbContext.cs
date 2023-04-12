using Microsoft.EntityFrameworkCore;
namespace BaiTap.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            
        }
        public DbSet<SinhVien_tbl> SinhVien_tbl { get; set; }
        public DbSet<Sach_tbl> Sach_tbl { get; set; }
        public DbSet<SinhVienSach_tbl> SinhVienSach_tbl { get; set; }

    }
}
