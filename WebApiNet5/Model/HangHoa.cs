namespace WebApiNet5.Model
{
    public class HangHoaVM
    {
        public string TenHangHoa { get; set; }

        public double DonGia { get; set; }
    }

    public class HangHoa : HangHoaVM
    {
        public string MaHangHoa { get; set; }
    }
}
