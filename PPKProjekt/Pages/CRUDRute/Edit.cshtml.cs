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

namespace PPKProjekt.Pages.CRUDRute
{
    public class EditModel : PageModel
    {
        private IRutaRepository rutarepo;
        private IPutniNalogRepository pnrepo;

        public EditModel()
        {
            this.rutarepo = new RutaRepository();
            this.pnrepo = new PutniNalogRepository();
        }
        [BindProperty]
        public Ruta Ruta { get; set; }

        public  IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Ruta = rutarepo.FindById(((int)id));
            

            if (Ruta == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            int id = rutarepo.FindById(Ruta.IDRuta).PutniNalog.IDPutniNalog;
            Ruta.PutniNalog = pnrepo.FindById(id);
            try
            {
                rutarepo.Update(Ruta);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RutaExists(Ruta.IDRuta))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("../CRUDPutniNalog/Index");
        }

        private bool RutaExists(int id)
        {
            return rutarepo.FindById(id)!=null;
        }
    }
}
