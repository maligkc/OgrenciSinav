using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTO
{
    public class TBLDERS
    {
        [Key]
        public int DERSID { get; set; }
        public string DERSAD { get; set; }
    }
}
