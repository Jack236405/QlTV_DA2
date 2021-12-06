using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PJC.Models
{
    public class TaiKhoan
    {
        private string nguoiDung;
        private string matKhau;
        private int phanQuyen;
        private string tenND;
        private string sDT;
        private string cMND;
        [Display(Name = "Mật khẩu: ")]
        public string MatKhau { get => matKhau; set => matKhau = value; }
        [Display(Name = "Phân quyền: ")]
        public int PhanQuyen { get => phanQuyen; set => phanQuyen = value; }
        [Display(Name = "Tên người dùng: ")]
        public string TenND { get => tenND; set => tenND = value; }
        [Display(Name = "Số điện thoại: ")]
        public string SDT { get => sDT; set => sDT = value; }
        [Display(Name = "CMND/Thẻ Căn Cước: ")]
        public string CMND { get => cMND; set => cMND = value; }
        [Display(Name = "Tài Khoản: ")]
        public string NguoiDung { get => nguoiDung; set => nguoiDung = value; }

    }
}
