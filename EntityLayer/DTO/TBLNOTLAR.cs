using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EntityLayer.DTO
{
    public class TBLNOTLAR
    {
        [Key]
        public int NotId { get; set; }
        public int Ogr { get; set; }
        public int Ders { get; set; }
        [Column("SINAV1")]
        public int Sinav1 { get; set; }
        [Column("SINAV2")]
        public int Sinav2 { get; set; }
        public decimal Ortalama { get; set; }
        public bool Durum { get; set; }
    }
}
