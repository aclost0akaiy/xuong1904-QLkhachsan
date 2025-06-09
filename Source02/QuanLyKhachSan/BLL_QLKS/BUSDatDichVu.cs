using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_QLKS;
using DTO_QLKS;
using DTO_QuanLyKhachSan;

namespace BLL_QLKS
{
    public class BUSDatDichVu
    {
        DALDatDichVu dalDatDichVu = new DALDatDichVu();
        public List<DichVu> GetDichVuList()
        {
            return dalDatDichVu.selectAll(string.Empty);
        }

        public string InsertDichVu(DichVu dichVu)
        {
            try
            {
                dichVu.HoaDonThueID = dalDatDichVu.generateDichVu();
                if (string.IsNullOrEmpty(dichVu.DichVuID))
                {
                    return "Mã dịch vụ không hợp lệ.";
                }

                dalDatDichVu.insertDichVu(dichVu);
                return string.Empty;
            }
            catch (Exception ex)
            {
                //return "Thêm mới không thành công.";
                return "Lỗi: " + ex.Message;
            }
        }
        public string UpdateDichVu(DichVu dichVu)
        {
            try
            {
                if (string.IsNullOrEmpty(dichVu.HoaDonThueID))
                {
                    return "Mã phiếu không hợp lệ.";
                }

                dalDatDichVu.updateDichVu(dichVu);
                return string.Empty;
            }
            catch (Exception ex)
            {
                //return "Cập nhật không thành công.";
                return "Lỗi: " + ex.Message;
            }
        }

        public string DeleteDichVu(string dichVu)
        {
            try
            {
                if (string.IsNullOrEmpty(dichVu))
                {
                    return "Mã phiếu bán hàng không hợp lệ.";
                }

                dalDatDichVu.deleteDichVu(dichVu);
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
