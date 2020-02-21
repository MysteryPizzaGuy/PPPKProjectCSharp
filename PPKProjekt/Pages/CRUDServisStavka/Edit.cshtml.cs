using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PPKProjekt.Models;
using PPKProjekt.Repository;

namespace PPKProjekt.Pages.CRUDServisStavka
{
    public class EditModel : PageModel
    {

        private IServisStavkaRepository servisStavkaRepository;

        public EditModel()
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }


            try
            {
                servisStavkaRepository.Update(ServisStavka);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServisStavkaExists(ServisStavka.IDServisStavka))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ServisStavkaExists(int id)
        {
            return servisStavkaRepository.FindById(id) != null;
        }
    }
}
