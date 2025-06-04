using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLKS
{
    public class TrangThaiPhong
    {
        public string MaTrangThai { get; set; } // Mã trạng thái phòng
        public string TenTrangThai { get; set; } // Tên trạng thái phòng
        public string MaHoaDon { get; set; } // Mã phòng liên kết
        public DateTime NgayCapNhat { get; set; } // Ngày tạo trạng thái phòng
    }
}
