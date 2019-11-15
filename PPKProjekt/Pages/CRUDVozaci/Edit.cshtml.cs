using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PPKProjekt;
using PPKProjekt.Models;
using PPKProjekt.Repository;

namespace PPKProjekt.Pages.CRUDVozaci
{
    public class EditModel : PageModel
    {
        private readonly IVozacRepository repo;

        public EditModel()
        {
            repo = new VozacRepository();
        }

        [BindProperty]
        public Vozac Vozac { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Vozac = repo.FindAll().FirstOrDefault(m => m.IDVozac == id);

            if (Vozac == null)
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

            //_context.Attach(Vozac).State = EntityState.Modified;
            

            try
            {
                repo.Update(Vozac);
            }
            catch (SqlException)
            {
                if (!VozacExists(Vozac.IDVozac))
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

        private bool VozacExists(int id)
        {
            return repo.FindAll().Any(e => e.IDVozac == id);
        }
    }
}
