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
    public class DeleteModel : PageModel
    {
        private IServisStavkaRepository servisStavkaRepository;

        public DeleteModel()
        {
            servisStavkaRepository = new ServisStavkaRepository();
        }

        [BindProperty]
        public ServisStavka ServisStavka { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
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

        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ServisStavka = servisStavkaRepository.FindById((int)id);

            if (ServisStavka != null)
            {
                servisStavkaRepository.Delete(ServisStavka);
            }

            return RedirectToPage("./Index");
        }
    }
}
