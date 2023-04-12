using System.ComponentModel.DataAnnotations;

namespace BaiTap.Models
{
    public class SinhVien_tbl
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage ="Hãy Nhập Tên Sinh Viên")]
        public string TenSinhVien { get; set; }
        [Required(ErrorMessage = "Hãy Nhập MSSV")]
        public string MSSV { get; set; }
        [Required(ErrorMessage = "Hãy Nhập Số Điện Thoại")]
        public string DienThoai { get; set; }
        [Required(ErrorMessage = "Hãy Nhập Địa Chỉ")]
        public string DiaChi { get; set; }
    }
}
