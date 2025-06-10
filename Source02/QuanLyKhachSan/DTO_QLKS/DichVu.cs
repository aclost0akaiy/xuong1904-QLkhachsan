using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLKS
{
    public class DichVu
    {
        public string DichVuID { get; set; }
        public string HoaDonThueID { get; set; }
        public DateTime NgayTao { get; set; } = DateTime.Now; // Giá trị mặc định
        public bool TrangThai { get; set; } = true; // Giá trị mặc định là true
        public string TrangThaiText => TrangThai ? "Hoạt động" : "Ngừng hoạt động";
        public string GhiChu { get; set; }
    }
}
