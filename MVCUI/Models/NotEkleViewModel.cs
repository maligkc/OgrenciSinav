using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace MVCUI.Models
{
    public class NotEkleViewModel
    {

        [Required(ErrorMessage = "Ad alanı boş bırakılamaz.")]
        public string Ad { get; set; }

        [Required(ErrorMessage = "Soyad alanı boş bırakılamaz.")]
        public string Soyad { get; set; }

        [Required(ErrorMessage = "Okul numarası boş bırakılamaz.")]
        public int OkulNo { get; set; }

        [Required(ErrorMessage = "Ders seçimi zorunludur.")]
        public int DersId { get; set; }

        [Required(ErrorMessage = "Vize notu boş bırakılamaz.")]
        [Range(0, 100, ErrorMessage = "Vize notu 0 ile 100 arasında olmalıdır.")]
        public int Sinav1 { get; set; }

        [Required(ErrorMessage = "Final notu boş bırakılamaz.")]
        [Range(0, 100, ErrorMessage = "Final notu 0 ile 100 arasında olmalıdır.")]
        public int Sinav2 { get; set; }
        public List<SelectListItem> Dersler { get; set; }
    }
}
