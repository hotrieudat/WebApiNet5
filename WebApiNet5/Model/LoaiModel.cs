using System.ComponentModel.DataAnnotations;

namespace WebApiNet5.Model
{
    public class LoaiModel
    {
        [Required]
        [MaxLength(50)]
        public string TenLoai { get; set; }
    }
}
