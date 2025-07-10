using EntityLayer.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class NotlarRepository
    {
        OgrenciContext context;

        public NotlarRepository(OgrenciContext context)
        {
            this.context = context;
        }

        public List<NotlarDto> NotlariGetirProsedur()
        {
            return context.Notlar.FromSqlRaw("EXEC PROC_NOTLARI_GETIR").ToList();
        }
    }
}
