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
    public class DetailsModel : PageModel
    {
        private IServisStavkaRepository servisStavkaRepository;

        public DetailsModel()
        {
            servisStavkaRepository = new ServisStavkaRepository();
        }

        public ServisStavka ServisStavka { get; set; }

        public  IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ServisStavka = servisStavkaRepository.FindById((int)id);

            if (ServisStavka == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
