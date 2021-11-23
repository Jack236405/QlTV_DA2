using System;
using System.ComponentModel.DataAnnotations;

namespace PJC.Models
{
    public class CTPM
    {
        private string maPM;
        private string maSach;
        private DateTime? ngayTra;
        private int tinhTrangSach;
        private int? tinhTrangTra;
        private string? nguoiDung;
        private string? ghiChu;
        private int? tienPhat;
        [Display(Name = "Mã phiếu mượn:")]
        public string MaPM { get => maPM; set => maPM = value; }
        [Display(Name = "Mã sách:")]
        public string MaSach { get => maSach; set => maSach = value; }
        [Display(Name = "Ngày trả:")]
        [DataType(DataType.Date)]
        public DateTime? NgayTra { get => ngayTra; set => ngayTra = value; }
        [Display(Name = "Tình trạng mượn:")]
        public int TinhTrangSach { get => tinhTrangSach; set => tinhTrangSach = value; }
        [Display(Name = "Tình trạng trả:")]
        public int? TinhTrangTra { get => tinhTrangTra; set => tinhTrangTra = value; }
        [Display(Name = "Thủ thư nhận sách:")]
        public string? NguoiDung { get => NguoiDung; set => NguoiDung = value; }
        [Display(Name = "Ghi chú:")]
        public string? GhiChu { get => ghiChu; set => ghiChu = value; }
        [Display(Name = "Tiền phạt:")]
        public int? TienPhat { get => tienPhat; set => tienPhat = value; }

    }
}
