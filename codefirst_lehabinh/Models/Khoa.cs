namespace codefirst_lehabinh.Models
{
    public class Khoa
    {
        public int KhoaId { get; set; }
        public string TenKhoa { get; set; }

        public List<Lop> Lops { get; set; }
    }
}
