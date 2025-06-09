using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLyKhachSan
{
    public class DatPhong
    {
        public string? HoaDonThueID { get; set; }
        public string? KhachHangID { get; set; }

        public string? PhongID { get; set; }
        public DateTime NgayDen { get; set; } = new DateTime();
        public DateTime NgayDi { get; set; } = new DateTime();
        public string? MaNV { get; set; }
        public string? GhiChu { get; set; }
    }
}
