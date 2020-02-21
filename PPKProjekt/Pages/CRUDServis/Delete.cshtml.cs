using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PPKProjekt.Models;
using PPKProjekt.Repository;

namespace PPKProjekt.Pages.CRUDServis
{
    public class DeleteModel : PageModel
    {
        private IServisRepository servrepo;

        public DeleteModel()
        {
            servrepo = new ServisRepository();
        }


        [BindProperty]
        public Servis Servis { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Servis = servrepo.FindById((int)id);

            if (Servis == null)
            {
                return NotFound();
            }
            return Page();
        }

        public  IActionResult OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Servis = servrepo.FindById((int)id);

            if (Servis != null)
            {
                servrepo.Delete(Servis);
            }

            return RedirectToPage("./Index");
        }
    }
}
