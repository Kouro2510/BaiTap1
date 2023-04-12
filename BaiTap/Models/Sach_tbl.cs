using System.ComponentModel.DataAnnotations;

namespace BaiTap.Models
{
    public class Sach_tbl
    {
        [Key]
        public int ID { get; set; }
        public string TenSach { get; set; }
        public string TacGia { get; set; }
        public double GiaTien { get; set; }
        public string NhaXuatBan { get; set; }
    }
}
