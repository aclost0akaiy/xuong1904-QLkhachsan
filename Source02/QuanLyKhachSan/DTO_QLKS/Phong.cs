using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLKS
{
    public class Phong
    {
        public string MaPhong { get; set; } // Mã phòng
        public string TenPhong { get; set; } // Tên phòng
        public string MaLoaiPhong { get; set; } // Mã loại phòng
        public string GiaPhong { get; set; } // Tên loại phòng
        public DateTime NgayTao { get; set; } // Ngày tạo phòng
        public string GhiChu { get; set; } // Ghi chú về phòng
        public bool TinhTrang { get; set; } // true: Đang Hoạt Động, false: Tạm Ngưng
        public string TinhTrangText => TinhTrang ? "Đang Hoạt Động" : "Tạm Ngưng"; // Hiển thị trạng thái phòng
    }
}
