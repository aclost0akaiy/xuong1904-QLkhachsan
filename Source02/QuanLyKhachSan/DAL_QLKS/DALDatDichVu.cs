using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_QLKS;
using DTO_QLKS;
using DTO_QuanLyKhachSan;
using Microsoft.Data.SqlClient;

namespace DAL_QLKS
{
    public class DALDatDichVu
    {
        public string generateDichVu()
        {
            string prefix = "DVHD";
            string sql = "SELECT MAX(DichVuID) FROM DichVu";
            List<object> thamSo = new List<object>();
            object result = DBUtil.ScalarQuery(sql, thamSo);
            if (result != null && result.ToString().StartsWith(prefix))
            {
                string maxCode = result.ToString().Substring(4);
                int newNumber = int.Parse(maxCode) + 1;
                return $"{prefix}{newNumber:D3}";
            }

            return $"{prefix}001";
        }

        public void insertDichVu(DichVu datPhong)
        {
            try
            {
                string sql = @"INSERT INTO DichVu (DichVuID, HoaDonThueID, NgayTao, TrangThai, GhiChu) 
                   VALUES (@0, @1, @2, @3, @4)";
                List<object> thamSo = new List<object>();
                thamSo.Add(datPhong.DichVuID);
                thamSo.Add(datPhong.HoaDonThueID);
                thamSo.Add(datPhong.NgayTao);
                thamSo.Add(datPhong.TrangThai);
                thamSo.Add(datPhong.GhiChu);
                DBUtil.Update(sql, thamSo);
            }
            catch (Exception e)
            {
                throw;
            }

        }

        public void updateDichVu(DichVu datphong)
        {
            try
            {
                string sql = @"UPDATE DichVu 
                   SET HoaDonThueID = @1, NgayTao = @2, TrangThai = @3, GhiChu = @4
                   WHERE DichVuID = @0";
                List<object> thamSo = new List<object>();
                thamSo.Add(datphong.DichVuID);
                thamSo.Add(datphong.HoaDonThueID);
                thamSo.Add(datphong.NgayTao);
                thamSo.Add(datphong.TrangThai);
                thamSo.Add(datphong.GhiChu);
                DBUtil.Update(sql, thamSo);
            }
            catch (Exception e)
            {
                throw;
            }

        }

        public void deleteDichVu(string dichVuID)
        {
            try
            {
                string sql = "DELETE FROM DichVu WHERE DichVuID = @0";
                List<object> thamSo = new List<object>();
                thamSo.Add(dichVuID);
                DBUtil.Update(sql, thamSo);
            }
            catch (Exception e)
            {
                throw;
            }

        }
        public List<DichVu> SelectBySql(string sql, List<object> args, CommandType cmdType = CommandType.Text)
        {
            List<DichVu> list = new List<DichVu>();
            try
            {
                SqlDataReader reader = DBUtil.Query(sql, args);
                while (reader.Read())
                {
                    DichVu entity = new DichVu();
                    entity.DichVuID = reader.GetString("DichVuID");
                    entity.HoaDonThueID = reader.GetString("HoaDonThueID");
                    entity.NgayTao = reader.GetDateTime("NgayTao");
                    entity.TrangThai = reader.GetBoolean("TrangThai");
                    entity.GhiChu = reader.GetString("GhiChu");
                    list.Add(entity);
                }
            }
            catch (Exception)
            {
                throw new Exception("Lỗi khi truy vấn dữ liệu dịch vụ.");
            }
            return list;
        }

        public List<DichVu> selectAll(string hoadonthueid)
        {
            List<object> param = new List<object>();
            string sql = @"SELECT * FROM DichVu";

            if (!string.IsNullOrEmpty(hoadonthueid))
            {
                sql += " WHERE dp.DichVuID = @0";
                param.Add(hoadonthueid);
            }

            return SelectBySql(sql, param);
        }

    }
}
