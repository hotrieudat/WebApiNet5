using System;
using System.Collections.Generic;

namespace WebApiNet5.Data
{
    public enum TinhTrangDonHang
    {
        New = 0,
        Payment,
        Complete,
        Cancel,
    }

    public class DonHang
    {
        public Guid MaDh { get; set; }

        public DateTime NgayDat { get; set; }

        public DateTime? NgayGiao { get; set; }

        public TinhTrangDonHang TinhTrangDonHang { get; set; }

        public string NguoiNhanHang { get; set; }

        public string DiaChiGiao { get; set; }

        public string SoDienThoai { get; set; }

        public ICollection<DonHangChiTiet> DonHangChiTiets { get; set; }

        public DonHang()
        {
            DonHangChiTiets = new List<DonHangChiTiet>();
        }
    }
}
