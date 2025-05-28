﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_KhachSan;

namespace UTil
{
public class AuthUtil
    {
        public static NhanVien user = null;
        public static bool IsLogin()
        {
            if (user == null)
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(user.MaNV))
            {
                return false;
            }
            return true;
        }
    }
}
