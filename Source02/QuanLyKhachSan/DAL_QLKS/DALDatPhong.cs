using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_QLKS;
using DTO_QuanLyKhachSan;
using Microsoft.Data.SqlClient;

namespace DAL_QLKS
{
    public class DALDatPhong
    {
        public string generateMaHoaDonID()
        {
            string prefix = "DP";
            string sql = "SELECT MAX(HoaDonThueID) FROM DatPhong";
            List<object> thamSo = new List<object>();
            object result = DBUtil.ScalarQuery(sql, thamSo);
            if (result != null && result.ToString().StartsWith(prefix))
            {
                string maxCode = result.ToString().Substring(3);
                int newNumber = int.Parse(maxCode) + 1;
                return $"{prefix}{newNumber:D3}";
            }

            return $"{prefix}001";
        }

        public void insertDatPhong(DatPhong datPhong)
        {
            try
            {
                string sql = @"INSERT INTO DatPhong (HoaDonThueID, KhachHangID, PhongID, NgayDen, NgayDi, MaNV, GhiChu) 
                   VALUES (@0, @1, @2, @3, @4, @5, @6)";
                List<object> thamSo = new List<object>();
                thamSo.Add(datPhong.HoaDonThueID);
                thamSo.Add(datPhong.KhachHangID);
                thamSo.Add(datPhong.PhongID);
                thamSo.Add(datPhong.NgayDen);
                thamSo.Add(datPhong.NgayDi);
                thamSo.Add(datPhong.MaNV);
                thamSo.Add(datPhong.GhiChu);
                DBUtil.Update(sql, thamSo);
            }
            catch (Exception e)
            {
                throw;
            }

        }

        public void updateDatPhong(DatPhong datphong)
        {
            try
            {
                string sql = @"UPDATE DatPhong 
                   SET KhachHangID = @1, PhongID = @2, NgayDen = @3, NgayDi = @4 , MaNV = @5, GhiChu = @6
                   WHERE HoaDonThueID = @0";
                List<object> thamSo = new List<object>();
                thamSo.Add(datphong.HoaDonThueID);
                thamSo.Add(datphong.KhachHangID);
                thamSo.Add(datphong.PhongID);
                thamSo.Add(datphong.NgayDen);
                thamSo.Add(datphong.NgayDi);
                thamSo.Add(datphong.MaNV);
                thamSo.Add(datphong.GhiChu);
                DBUtil.Update(sql, thamSo);
            }
            catch (Exception e)
            {
                throw;
            }

        }

        public void deleteDatPhong(string hoaDonThueID)
        {
            try
            {
                string sql = "DELETE FROM DatPhong WHERE HoaDonThueID = @0";
                List<object> thamSo = new List<object>();
                thamSo.Add(hoaDonThueID);
                DBUtil.Update(sql, thamSo);
            }
            catch (Exception e)
            {
                throw;
            }

        }
        public List<DatPhong> SelectBySql(string sql, List<object> args, CommandType cmdType = CommandType.Text)
        {
            List<DatPhong> list = new List<DatPhong>();
            try
            {
                SqlDataReader reader = DBUtil.Query(sql, args);
                while (reader.Read())
                {
                    DatPhong entity = new DatPhong();
                    entity.HoaDonThueID = reader.GetString("HoaDonThueID");
                    entity.KhachHangID = reader.GetString("KhachHangID");
                    entity.PhongID = reader.GetString("PhongID");
                    entity.NgayDen = reader.GetDateTime("NgayDen");
                    entity.NgayDi = reader.GetDateTime("NgayDi");
                    entity.MaNV = reader.GetString("MaNV");
                    entity.GhiChu = reader.GetString("GhiChu");
                    list.Add(entity);
                }
            }
            catch (Exception)
            {
                throw new Exception("Lỗi khi truy vấn dữ liệu DatPhong.");
            }
            return list;
        }

        public List<DatPhong> selectAll(string hoadonthueid)
        {
            List<object> param = new List<object>();
            string sql = @"SELECT dp.HoaDonThueID, dp.KhachHangID, kh.HoTen, 
                          dp.PhongID, p.TenPhong, dp.NgayDen, dp.NgayDi, 
                          dp.MaNV, nv.HoTen AS TenNhanVien, dp.GhiChu 
                   FROM DatPhong dp 
                   INNER JOIN KhachHang kh ON dp.KhachHangID = kh.KhachHangID 
                   INNER JOIN Phong p ON dp.PhongID = p.PhongID 
                   INNER JOIN NhanVien nv ON dp.MaNV = nv.MaNV";

            if (!string.IsNullOrEmpty(hoadonthueid))
            {
                sql += " WHERE dp.HoaDonThueID = @0";
                param.Add(hoadonthueid);
            }

            return SelectBySql(sql, param);
        }

    }
}
