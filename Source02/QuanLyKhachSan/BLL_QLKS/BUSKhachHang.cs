using DAL_QLKS;
using DTO_QLKS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_QLKS
{
    public class BUSKhachHang
    {
        DALKhachHang dalKhachHang = new DALKhachHang();

        public List<KhachHang> GetKhachHangList()
        {
            return dalKhachHang.selectAll();
        }

        // Thêm phương thức mới để chuyển đổi dữ liệu hiển thị
        public List<object> GetKhachHangListForDisplay()
        {
            var nhanVienList = dalKhachHang.selectAll();
            var displayList = nhanVienList.Select(nv => new
            {
                nv.KhachHangID,
                nv.HoTen,
                nv.DiaChi,
                nv.GioiTinh, // nếu nv.GioiTinh là string sẵn
                nv.SoDienThoai,
                nv.CCCD,
                nv.NgayTao,
                TrangThai = nv.TrangThai ? "Đang hoạt động" : "Ngưng hoạt động",
                nv.GhiChu
            }).ToList<object>();

            return displayList;
        }
        public string InsertKhachHang(KhachHang nv)
        {
            try
            {
                nv.KhachHangID = dalKhachHang.generateKhachHangID();
                if (string.IsNullOrEmpty(nv.KhachHangID))
                {
                    return "Mã khách hàng không hợp lệ";
                }
                dalKhachHang.insert(nv);
                return string.Empty;
            }
            catch (Exception ex)
            {
                return "Lỗi khi thêm nhân viên: " + ex.Message;
            }
        }
        public string UpdateKhachHang(KhachHang nv)
        {
            try
            {
                if (string.IsNullOrEmpty(nv.KhachHangID))
                {
                    return "Mã khách hàng không hợp lệ.";
                }

                dalKhachHang.updateKhachHang(nv);
                return string.Empty;
            }
            catch (Exception ex)
            {
                //return "Cập nhật không thành công.";
                return "Lỗi: " + ex.Message;
            }
        }
        // Thêm phương thức xóa nhân viên
        public string DeleteKhachHang(string maKh)
        {
            try
            {
                if (string.IsNullOrEmpty(maKh))
                {
                    return "Mã khách hàng không hợp lệ.";
                }

                dalKhachHang.deleteKhachHang(maKh);
                return string.Empty;
            }
            catch (Exception ex)
            {
                //return "Xóa không thành công.";
                return "Lỗi: " + ex.Message;
            }
        }

    }
}
