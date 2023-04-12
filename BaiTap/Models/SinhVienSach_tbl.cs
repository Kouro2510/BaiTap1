using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaiTap.Models
{
    public class SinhVienSach_tbl
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("Sach_tbl")]
        public int IDSach { get; set; }
        [ForeignKey("SinhVien_tbl")]
        public int IDSinhVien { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH-mm}", ApplyFormatInEditMode = true)]
        public DateTime? NgayMuonSach { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH-mm}", ApplyFormatInEditMode = true)]
        public DateTime? NgayTra { get; set; }

        public virtual Sach_tbl Sach_tbl { get; set; }
        public virtual SinhVien_tbl SinhVien_tbl { get; set; }
    }
}
