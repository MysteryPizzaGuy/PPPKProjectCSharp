using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PPKProjekt.Models;
using PPKProjekt.Repository;

namespace PPKProjekt.Pages.CRUDRute
{
    public class CreateModel : PageModel
    {
        private IRutaRepository rutarepo;
        private IPutniNalogRepository pnRepo;


        public CreateModel()
        {
            this.rutarepo = new RutaRepository();
            this.pnRepo = new PutniNalogRepository();
        }

        public IActionResult OnGet(int? id)
        {
            pnID = (int)id;
            return Page();
        }

        [BindProperty]
        public int pnID { get; set; }

        [BindProperty]
        public Ruta Ruta { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Ruta.PutniNalog = pnRepo.FindById(pnID);

            rutarepo.Create(Ruta);

            return RedirectToPage("../CRUDPutniNalog/Index");
        }
    }
}