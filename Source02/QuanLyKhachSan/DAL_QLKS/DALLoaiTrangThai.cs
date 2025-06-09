
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
    public class DALLoaiTrangThai
    {

        public List<LoaiTrangThaiPhong> SelectBySql(string sql, List<object> args, CommandType cmdType = CommandType.Text)
        {
            List<LoaiTrangThaiPhong> list = new List<LoaiTrangThaiPhong>();
            try
            {
                SqlDataReader reader = DBUtil.Query(sql, args);
                while (reader.Read())
                {
                    LoaiTrangThaiPhong entity = new LoaiTrangThaiPhong();
                    entity.LoaiTrangThaiID = reader.GetString("LoaiTrangThaiID");
                    entity.TenTrangThai = reader.GetString("TenTrangThai");
                   
                    list.Add(entity);
                  
                }
            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }

        public List<LoaiTrangThaiPhong> selectAll()
        {
            String sql = "SELECT * FROM LoaiTrangThaiDatPhong";
            return SelectBySql(sql, new List<object>());
        }

        public List<LoaiTrangThaiPhong> SearchLoaiTrangThaiPhong(string keyword)
        {
            string sql = "SELECT * FROM LoaiTrangThaiDatPhong WHERE LoaiTrangThaiID LIKE " + $"N'%{keyword}%' COLLATE Latin1_General_CI_AI" + " OR TenTrangThai LIKE " + $"N'%{keyword}%' COLLATE Latin1_General_CI_AI";
            // + " OR Email LIKE "+ $"N'%{keyword}%' COLLATE Latin1_General_CI_AI";
            List<object> thamSo = new List<object>();
            return SelectBySql(sql, thamSo);
        }


        public LoaiTrangThaiPhong selectById(string id)
        {
            String sql = "SELECT * FROM LoaiTrangThaiDatPhong WHERE LoaiTrangThaiID=@0";
            List<object> thamSo = new List<object>();
            thamSo.Add(id);
            List<LoaiTrangThaiPhong> list = SelectBySql(sql, thamSo);
            return list.Count > 0 ? list[0] : null;
        }

        //public void insertLoaiTrangThaiPhong(LoaiTrangThaiPhong nv)
        //{
        //    try
        //    {
        //        string sql = @"INSERT INTO LoaiTrangThaiPhong (LoaiTrangThaiID, TenTrangThai) 
        //           VALUES (@0, @1, @2, @3, @4, @5, @6, @7)";
        //        List<object> thamSo = new List<object>();
        //        thamSo.Add(nv.LoaiTrangThaiID);
        //        thamSo.Add(nv.TenTrangThai);
        //        DBUtil.Update(sql, thamSo);
        //    }
        //    catch (Exception e)
        //    {
        //        throw;
        //    }

        //}
        public string insertLoaiTrangThaiPhong(LoaiTrangThaiPhong nv)
        {
            try
            {
                string sql = @"INSERT INTO LoaiTrangThaiDatPhong (LoaiTrangThaiID, TenTrangThai) 
                OUTPUT INSERTED.LoaiTrangThaiID VALUES (@0, @1)";
                List<object> thamSo = new List<object>();
                thamSo.Add(nv.LoaiTrangThaiID);
                thamSo.Add(nv.TenTrangThai);
               
                return (string)DBUtil.ScalarQuery(sql, thamSo);
            }
            catch (Exception e)
            {
                throw;
            }

        }

        public void updateLoaiTrangThaiPhong(LoaiTrangThaiPhong nv)
        {
            try
            {
                string sql = @"UPDATE LoaiTrangThaiDatPhong 
                   SET TenTrangThao = @1 WHERE MaNV = @0";
                List<object> thamSo = new List<object>();
                thamSo.Add(nv.LoaiTrangThaiID);
                thamSo.Add(nv.TenTrangThai);
              
                DBUtil.Update(sql, thamSo);
            }
            catch (Exception e)
            {
                throw;
            }

        }

        public void deleteLoaiTrangThaiPhong(string loaiID)
        {
            try
            {
                string sql = "DELETE FROM LoaiTrangThaiDatPhong WHERE LoaiTrangThaiID = @0";
                List<object> thamSo = new List<object>();
                thamSo.Add(loaiID);
                DBUtil.Update(sql, thamSo);
            }
            catch (Exception e)
            {
                throw;
            }

        }

        public string generateMaNV()
        {
            string prefix = "TT";
            string sql = "SELECT MAX(LoaiTrangThaiID) FROM LoaiTrangThaiDatPhong";
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
