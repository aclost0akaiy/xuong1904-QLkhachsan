using DTO_QLKS;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QLKS
{
    public class DALKhachHang
    {
        public List<KhachHang> selectBySql(string sql, List<object> args, CommandType cmdType = CommandType.Text)
        {
            List<KhachHang> list = new List<KhachHang>();
            try
            {
                SqlDataReader reader = DBUtil.Query(sql, args);
                while (reader.Read())
                {
                    KhachHang entity = new KhachHang();
                    entity.KhachHangID = reader.GetString(reader.GetOrdinal("KhachHangID"));
                    entity.HoTen = reader.GetString(reader.GetOrdinal("HoTen"));
                    entity.DiaChi = reader.GetString(reader.GetOrdinal("DiaChi"));
                    entity.GioiTinh = reader.GetString(reader.GetOrdinal("GioiTinh"));
                    entity.SoDienThoai = reader.IsDBNull(reader.GetOrdinal("SoDienThoai")) ? null : reader.GetString(reader.GetOrdinal("SoDienThoai"));
                    entity.CCCD = reader.IsDBNull(reader.GetOrdinal("CCCD")) ? null : reader.GetString(reader.GetOrdinal("CCCD"));
                    entity.NgayTao = (DateTime)(reader.IsDBNull(reader.GetOrdinal("NgayTao")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("NgayTao")));
                    entity.TrangThai = reader.IsDBNull(reader.GetOrdinal("TrangThai")) ? false : reader.GetBoolean(reader.GetOrdinal("TrangThai"));
                    int ghiChuIndex = reader.GetOrdinal("GhiChu");
                    entity.GhiChu = reader.IsDBNull(ghiChuIndex) ? null : reader.GetString(ghiChuIndex);
                    list.Add(entity);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }
        public List<KhachHang> selectAll()
        {
            string sql = "SELECT * FROM KhachHang";
            return selectBySql(sql, []);
        }
        public KhachHang selectById(string id)
        {
            string sql = "SELECT * FROM KhachHang WHERE KhachHangID=@0";
            List<object> thamSo = [id];
            List<KhachHang> list = selectBySql(sql, thamSo);
            return list.Count > 0 ? list[0] : null;
        }
        public void insert(KhachHang entity)
        {
            string sql = "INSERT INTO KhachHang (KhachHangID, HoTen, DiaChi, GioiTinh, SoDienThoai, CCCD, NgayTao, TrangThai, GhiChu) VALUES (@0, @1, @2, @3, @4, @5, @6, @7, @8)";
            List<object> thamSo =
            [
                entity.KhachHangID,
                entity.HoTen,
                entity.DiaChi,
                entity.GioiTinh,
                entity.SoDienThoai,
                entity.CCCD,
                entity.NgayTao,
                entity.TrangThai,
                entity.GhiChu,
            ];
            DBUtil.Update(sql, thamSo);
        }

        public void updateKhachHang(KhachHang nv)
        {
            try
            {
                string sql = @"UPDATE KhachHang 
                   SET HoTen = @1, DiaChi = @2, GioiTinh = @3, SoDienThoai = @4, CCCD = @5, NgayTao = @6, TrangThai = @7, GhiChu = @8 
                   WHERE KhachHangID = @0";
                List<object> thamSo = new List<object>();
                thamSo.Add(nv.KhachHangID);
                thamSo.Add(nv.HoTen);
                thamSo.Add(nv.DiaChi);
                thamSo.Add(nv.GioiTinh);
                thamSo.Add(nv.SoDienThoai);
                thamSo.Add(nv.CCCD);
                thamSo.Add(nv.NgayTao);
                thamSo.Add(nv.TrangThai);
                thamSo.Add(nv.GhiChu);
                DBUtil.Update(sql, thamSo);
            }
            catch (Exception e)
            {
                throw;
            }

        }

        public void deleteKhachHang(string maNv)
        {
            try
            {
                string sql = "DELETE FROM KhachHang WHERE KhachHangID = @0";
                List<object> thamSo = new List<object>();
                thamSo.Add(maNv);
                DBUtil.Update(sql, thamSo);
            }
            catch (Exception e)
            {
                throw;
            }

        }

        public string generateKhachHangID()
        {
            string prefix = "KH";
            string sql = "SELECT MAX(KhachHangID) FROM KhachHang";
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
    }
}
