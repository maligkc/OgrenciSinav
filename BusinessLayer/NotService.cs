using DataAccessLayer;
using EntityLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class NotService
    {
        NotlarRepository notlarRepository;

        public NotService(NotlarRepository notlarRepository)
        {
            this.notlarRepository = notlarRepository;
        }
        public List<NotlarDto> NotlariGetir()
        {
            return notlarRepository.NotlariGetirProsedur();
        }
    }
}
