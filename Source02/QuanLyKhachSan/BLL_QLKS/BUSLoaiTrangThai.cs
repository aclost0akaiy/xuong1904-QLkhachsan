
using DAL_QLKS;
using DTO_QLKS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QLKS
{
    public class BusLoaiTrangThai
    {
        DALLoaiTrangThai dalTrangThai = new DALLoaiTrangThai();

        

        public List<LoaiTrangThaiPhong> GetLoaiTrangThaiPhongList()
        {
            return dalTrangThai.selectAll();
        }

        public List<LoaiTrangThaiPhong> SearchLoaiTrangThaiPhong(string keyword)
        {
            List<LoaiTrangThaiPhong> nv = new List<LoaiTrangThaiPhong>();
            try
            {
                return dalTrangThai.SearchLoaiTrangThaiPhong(keyword);
            }
            catch (Exception ex)
            {
                return nv;
            }
        }
        public string InsertLoaiTrangThaiPhong(LoaiTrangThaiPhong loai)
        {
            try
            {
                loai.LoaiTrangThaiID = dalTrangThai.generateMaNV();
                if (string.IsNullOrEmpty(loai.LoaiTrangThaiID))
                {
                    return "Mã loại phòng không hợp lệ.";
                }
               
                string result = dalTrangThai.insertLoaiTrangThaiPhong(loai);
                return string.Empty;
            }
            catch (Exception ex)
            {
                //return "Thêm mới không thành công.";
                return "Lỗi: " + ex.Message;
            }
        }

        public string UpdateLoaiTrangThaiPhong(LoaiTrangThaiPhong loai)
        {
            try
            {
                if (string.IsNullOrEmpty(loai.LoaiTrangThaiID))
                {
                    return "Mã loại phòng không hợp lệ.";
                }

                dalTrangThai.updateLoaiTrangThaiPhong(loai);
                return string.Empty;
            }
            catch (Exception ex)
            {
                //return "Cập nhật không thành công.";
                return "Lỗi: " + ex.Message;
            }
        }

        public string DeleteLoaiTrangThaiPhong(string loai)
        {
            try
            {
                if (string.IsNullOrEmpty(loai))
                {
                    return "Mã loại phòng không hợp lệ.";
                }

                dalTrangThai.deleteLoaiTrangThaiPhong(loai);
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
