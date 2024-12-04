using System.ComponentModel.DataAnnotations;

namespace WebApplication12.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tiêu đề là bắt buộc")]
        [StringLength(100, ErrorMessage = "Tiêu đề không được vượt quá 100 ký tự")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Tác giả là bắt buộc")]
        [StringLength(50, ErrorMessage = "Tên tác giả không được vượt quá 50 ký tự")]
        public string Author { get; set; }

        [StringLength(500, ErrorMessage = "Mô tả không được vượt quá 500 ký tự")]
        public string Description { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Giá phải là số dương")]
        public decimal Price { get; set; }

        [Url(ErrorMessage = "Đường dẫn hình ảnh không hợp lệ")]
        public string Image { get; set; }
    }
}