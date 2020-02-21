using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PPKProjekt.Models;

using PPKProjekt.Repository;

namespace PPKProjekt.Pages.CRUDServisStavka
{
    public class IndexModel : PageModel
    {

        private IServisStavkaRepository servisStavkaRepository;

        public IndexModel()
        {
            servisStavkaRepository= new ServisStavkaRepository();
        }

        public IList<ServisStavka> ServisStavka { get;set; }

        public void OnGet()
        {
            ServisStavka = servisStavkaRepository.FindAll().ToList();
        }
    }
}
