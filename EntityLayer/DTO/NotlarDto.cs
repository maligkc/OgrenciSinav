using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTO
{
    public class NotlarDto
    {
        public int NotId { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public int OkulNo { get; set; }
        public int OgrId { get; set; }
        public string DersAd { get; set; }
        public int Sinav1 { get; set; }
        public int Sinav2 { get; set; }
        public decimal Ortalama { get; set; }
        public bool Durum { get; set; }
    }
}
