using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCUI.Models;

namespace EntityLayer.DTO
{
    public class NotlarViewModel
    {
        public List<NotlarDto> Notlar { get; set; }
        public List<SelectListItem> Dersler { get; set; }
        public NotEkleViewModel EkleModel { get; set; }
    }
}
