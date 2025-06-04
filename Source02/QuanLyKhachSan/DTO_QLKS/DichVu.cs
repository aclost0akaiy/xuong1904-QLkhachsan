using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLKS
{
    public class DichVu
    {
        public string MaDV { get; set; }
        public string TenDV { get; set; }
        public DateTime NgayTao { get; set; }
        public string GhiChu { get; set; }
        public bool TinhTrang { get; set; }
        public string TinhTrangText => TinhTrang ? "Đang Hoạt Động" : "Tạm Ngưng";
        public string MaLoaiDV { get; set; } // Mã loại dịch vụ
        public string TenLoaiDV { get; set; } // Tên loại dịch vụ
        public decimal GiaDichVu { get; set; } // Đơn giá dịch vụ
        public string DonVi { get; set; } // Số lượng dịch vụ
        public string GhiChuLoaiDV { get; set; }
        public DateTime Ngaytao { get; set; } // Ngày tạo dịch vụ

    }
}
