using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_KhachSan;
using DTO_KhachSan;

namespace BLL_KhachSan
{
    public class BLL_NhanVien
    {
        private readonly DALNhanVien dalNhanVien = new DALNhanVien();

        public NhanVien DangNhap(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return null;
            }

            return dalNhanVien.getNhanVien(username, password);
        }
        public string UpdateNhanVien(NhanVien nv)
        {
            try
            {
                if (string.IsNullOrEmpty(nv.HoTen))
                {
                    return "Mã nhân viên không hợp lệ.";
                }
                dalNhanVien.update(nv);
                return string.Empty;
            }
            catch (Exception ex)
            {
                return "Lỗi: " + ex.Message;
            }
        }

        public bool ResetMatKhau(string email, string mk)
        {
            try
            {
                if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(mk))
                {
                    return false;
                }
                dalNhanVien.ResetMatKhau(mk, email);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public string InsertNhanVien(NhanVien nv)
        {
            try
            {
                nv.HoTen = dalNhanVien.generagteMaNV();
                if (string.IsNullOrEmpty(nv.HoTen))
                {
                    return "Ma nhan vien khong hop le!.";
                }
                if (dalNhanVien.checkEmailExist(nv.Email))
                {
                    return "Ho ten khong hop le!.";
                }
                dalNhanVien.insert(nv);
                return "Thêm nhân viên thành công!";
            }
            catch (Exception ex)
            {
                // Handle exception
                return "Error: " + ex.Message;
            }
        }


        public List<NhanVien> GetDSNhanVien()
        {
            return dalNhanVien.selectAll();
        }


        public string DeleteNhanVien(string maNV)
        {
            try
            {
                if (string.IsNullOrEmpty(maNV))
                {
                    return "Mã nhân viên không hợp lệ.";
                }

                dalNhanVien.deleteNhanVien(maNV);
                return string.Empty;
            }
            catch (Exception ex)
            {
                //return "Xóa không thành công.";
                return ex.Message;
            }
        }

        public NhanVien GetNhanVienById(string maNV)
        {
            if (string.IsNullOrEmpty(maNV))
            {
                return null;
            }
            return dalNhanVien.selectById(maNV);
        }
    }
}
