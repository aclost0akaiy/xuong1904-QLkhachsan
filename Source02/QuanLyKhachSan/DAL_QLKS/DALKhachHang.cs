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
                    entity.KhachHangID = reader.GetString("KhachHangID");  
                    entity.HoTen = reader.GetString("HoTen");       
                    entity.DiaChi = reader.GetString("DiaChi");       
                    entity.GioiTinh = reader.GetString("GioiTinh");     
                    entity.SoDienThoai = reader.GetString("SoDienThoai");  
                    entity.CCCD = reader.GetString("CCCD");
                    entity.NgayTao = reader.GetDateTime("NgayTao");
                    entity.TrangThai = reader.GetBoolean("TrangThai");
                    entity.GhiChu = reader.GetString("GhiChu");
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
            return selectBySql(sql, new List<Object>());
        }
        public KhachHang selectById(string id)
        {
            string sql = "SELECT * FROM KhachHang WHERE KhachHangID=@0";
            List<Object> thamSo = new List<Object>();
            thamSo.Add(id);
            List<KhachHang> list = selectBySql(sql, thamSo);
            return list.Count > 0 ? list[0] : null;
        }
        public void insert(KhachHang entity)
        {
            string sql = "INSERT INTO KhachHang (KhachHangID, HoTen, DiaChi, GioiTinh, SoDienThoai, CCCD, NgayTao, TrangThai, GhiChu) VALUES (@0, @1, @2, @3, @4, @5, @6, @7, @8)";
            List<object> thamSo = new List<object>();
            thamSo.Add(entity.KhachHangID);
            thamSo.Add(entity.HoTen);
            thamSo.Add(entity.DiaChi);
            thamSo.Add(entity.GioiTinh);
            thamSo.Add(entity.SoDienThoai);
            thamSo.Add(entity.CCCD);
            thamSo.Add(entity.NgayTao);
            thamSo.Add(entity.TrangThai);
            thamSo.Add(entity.GhiChu);
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
