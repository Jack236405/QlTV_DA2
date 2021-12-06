﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PJC.Models
{
    public class DoiMK
    {
        private string matKhau;
        private string matKhauCu;
        private string nguoiDung;
        private string passWordConfirm;
        [Display(Name = "Tài khoản:")]
        public string NguoiDung { get => nguoiDung; set => nguoiDung = value; }
        [Display(Name = "Mật khẩu cũ:")]
        public string MatKhauCu { get => matKhauCu; set => matKhauCu = value; }
        [Display(Name = "Mật khẩu mới:")]
        public string MatKhau { get => matKhau; set => matKhau = value; }
        [Display(Name = "Xác nhận mật khẩu mới:")]
        public string PassWordConfirm { get => passWordConfirm; set => passWordConfirm = value; }

    }
}
