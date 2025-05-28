using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_KhachSan;
using Microsoft.Data.SqlClient;

namespace DAL_KhachSan
{
    public class DALNhanVien
    {
        public NhanVien getNhanVien(string email, string password)
        {
            string sql = "SELECT * FROM NhanVien WHERE Email=@0 AND MatKhau=@1";
            List<object> thamSo = new List<object>();
            thamSo.Add(email);
            thamSo.Add(password);
            NhanVien nv = DBUtil.Value<NhanVien>(sql, thamSo);
            return nv;
        }
        public void ResetMatKhau(string mk, string email)
        {
            try
            {
                string sql = "UPDATE NhanVien SET MatKhau = @0 WHERE Email = @1";
                List<object> thamSo = new List<object>();
                thamSo.Add(mk);
                thamSo.Add(email);
                DBUtil.Update(sql, thamSo);

            }
            catch (Exception e)
            {
                throw;
            }
        }
        public NhanVien selectById(string id)
        {
            String sql = "SELECT * FROM NhanVien WHERE MaNV=@0";
            List<object> thamSo = new List<object>();
            thamSo.Add(id);
            List<NhanVien> list = selectBySql(sql, thamSo);
            return list.Count > 0 ? list[0] : null;
        }
        public void insert(NhanVien entity)
        {
            string sql = @"INSERT INTO NhanVien (MaNV, HoTen, VaiTro, GioiTinh, Email, DiaChi, TinhTrang) 
                   VALUES (@0, @1, @2, @3, @4, @5, @6)";
            List<object> thamSo = new List<object>
    {
        entity.MaNV,
        entity.HoTen,
        entity.VaiTro,
        entity.GioiTinh,
        entity.Email,
        entity.DiaChi,
        entity.TinhTrang
    };
            DBUtil.Update(sql, thamSo);
        }


        public void update(NhanVien entity)
        {
            string sql = @"UPDATE NhanVien 
                   SET HoTen = @1, VaiTro = @2, GioiTinh = @3, Email = @4, DiaChi = @5, TinhTrang = @6 
                   WHERE MaNV = @0";
            List<object> thamSo = new List<object>
    {
        entity.MaNV,
        entity.HoTen,
        entity.VaiTro,
        entity.GioiTinh,
        entity.Email,
        entity.DiaChi,
        entity.TinhTrang
    };
            DBUtil.Update(sql, thamSo);
        }

        public void deleteNhanVien(string maNv)
        {
            try
            {
                string sql = "DELETE FROM NhanVien WHERE MaNV = @0";
                List<object> thamSo = new List<object> { maNv };
                DBUtil.Update(sql, thamSo);
            }
            catch (Exception)
            {
                throw;
            }
        }


        private List<NhanVien> selectBySql(string sql, List<object> args, CommandType cmdType = CommandType.Text)
        {
            List<NhanVien> list = new List<NhanVien>();
            try
            {
                SqlDataReader reader = DBUtil.Query(sql, args);
                while (reader.Read())
                {
                    NhanVien entity = new NhanVien
                    {
                        MaNV = reader["MaNV"].ToString(),
                        HoTen = reader["HoTen"].ToString(),
                        VaiTro = reader["VaiTro"].ToString(),
                        GioiTinh = reader["GioiTinh"].ToString(),
                        Email = reader["Email"].ToString(),
                        DiaChi = reader["DiaChi"].ToString(),
                        TinhTrang = reader["TinhTrang"].ToString()
                    };
                    list.Add(entity);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }


        public List<NhanVien> selectAll()
        {
            string sql = "SELECT * FROM NhanVien";
            return selectBySql(sql, new List<object>());
        }

        public string generagteMaNV()
        {
            string prefix = "NV";
            string sql = "SELECT MAX(MaNV) FROM NhanVien";
            List<object> thamSo = new List<object>();
            object result = DBUtil.ScalarQuery(sql, thamSo);
            if (result != null && result.ToString().StartsWith(prefix))
            {
                string maxCode = result.ToString().Substring(2);
                int newNumber = int.Parse(maxCode) + 1;
                return $"{prefix}{newNumber:D3}";
            }

            return $"{prefix}001";
        }

        public bool checkEmailExist(string email)
        {
            string sql = "SELECT COUNT(*) FROM NhanVien WHERE Email=@0";
            List<object> thamSo = new List<object>();
            thamSo.Add(email);
            object result = DBUtil.ScalarQuery(sql, thamSo);
            return Convert.ToInt32(result) > 0;
        }
    }
}
