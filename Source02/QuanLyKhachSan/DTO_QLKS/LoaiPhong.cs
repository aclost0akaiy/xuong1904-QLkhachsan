using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLKS
{
    public class LoaiPhong
    {
        public string MaLoaiPhong { get; set; }
        public string TenLoaiPhong { get; set; }
        public int SoGiuong { get; set; }
        public DateTime NgayTao { get; set; }
        public string GhiChu { get; set; }
        public bool TrangThai { get; set; } // true: Đang Hoạt Động, false: Tạm Ngưng
        public string TrangThaiText => TrangThai ? "Đang Hoạt Động" : "Tạm Ngưng";
    }
}
