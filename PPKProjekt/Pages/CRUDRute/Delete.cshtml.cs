using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PPKProjekt.Models;
using PPKProjekt.Repository;

namespace PPKProjekt.Pages.CRUDRute
{
    public class DeleteModel : PageModel
    {
        private IRutaRepository rutarepo;

        public DeleteModel()
        {
            this.rutarepo = new RutaRepository();
        }

        [BindProperty]
        public Ruta Ruta { get; set; }

        public IActionResult OnGet(int? id, int? pnid)
        {
            if (id == null )
            {
                return NotFound();
            }

            Ruta = rutarepo.FindById((int)id);

            if (Ruta == null)
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

            Ruta = rutarepo.FindById((int)id);
            if (Ruta != null)
            {
                rutarepo.Delete(Ruta);
            }

            return RedirectToPage("../CRUDPutniNalog/Index");
        }
    }
}
