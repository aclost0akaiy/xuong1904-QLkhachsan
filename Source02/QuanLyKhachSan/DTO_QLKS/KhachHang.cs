using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLKS
{
    public class KhachHang
    {
        public string MaKH { get; set; }
        public string HoTen { get; set; }
        public string GioiTinh { get; set; }
        public string SoDienThoai { get; set; }
        public string CCCD { get; set; }
        public string QuocTich { get; set; }
        public DateTime NgaySinh { get; set; }
        public string TinhTrang { get; set; } // "Đang Hoạt Động" hoặc "Tạm Ngưng"
    }
}
