using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_QLKS;
using DTO_QuanLyKhachSan;

namespace BLL_QLKS
{
    public class BUSDatPhong
    {
        DALDatPhong dalDatPhong = new DALDatPhong();
        public List<DatPhong> GetDatPhongList()
        {
            return dalDatPhong.selectAll(string.Empty);
        }

        public string InsertDatPhong(DatPhong datPhong)
        {
            try
            {
                datPhong.HoaDonThueID = dalDatPhong.generateMaHoaDonID();
                if (string.IsNullOrEmpty(datPhong.HoaDonThueID))
                {
                    return "Mã phiếu bán hàng không hợp lệ.";
                }

                dalDatPhong.insertDatPhong(datPhong);
                return string.Empty;
            }
            catch (Exception ex)
            {
                //return "Thêm mới không thành công.";
                return "Lỗi: " + ex.Message;
            }
        }
        public string UpdateDatPhong(DatPhong datPhong)
        {
            try
            {
                if (string.IsNullOrEmpty(datPhong.HoaDonThueID))
                {
                    return "Mã phiếu không hợp lệ.";
                }

                dalDatPhong.updateDatPhong(datPhong);
                return string.Empty;
            }
            catch (Exception ex)
            {
                //return "Cập nhật không thành công.";
                return "Lỗi: " + ex.Message;
            }
        }

        public string DeleteDatPhong(string datPhong)
        {
            try
            {
                if (string.IsNullOrEmpty(datPhong))
                {
                    return "Mã phiếu bán hàng không hợp lệ.";
                }

                dalDatPhong.deleteDatPhong(datPhong);
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
