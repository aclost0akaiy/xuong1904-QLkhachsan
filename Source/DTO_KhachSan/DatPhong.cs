using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_KhachSan
{
    public class DatPhong
    {
        public string MaDatPhong { get; set; }
        public string MaKhachHang { get; set; }
        public string MaPhong { get; set; }
        public DateTime NgayDat { get; set; }
        public DateTime NgayTra { get; set; }
        public int SoLuongKhach { get; set; }
        public decimal TongTien { get; set; }
        public string TinhTrang { get; set; }
        public string GhiChu { get; set; }
    }
}
