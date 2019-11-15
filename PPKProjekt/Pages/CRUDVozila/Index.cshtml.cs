using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PPKProjekt.Models;
using PPKProjekt.Repository;

namespace PPKProjekt.Pages.CRUDVozaciila
{
    public class IndexModel : PageModel
    {
        private readonly IVoziloRepository repo;

        public IndexModel()
        {
            repo = new VoziloRepository();
        }
        public void OnPost()
        {
            repo.InsertTestCase();
            Vozilo = repo.FindAll().ToList();


        }
        public IList<Vozilo> Vozilo { get; set; }

        public void OnGet()
        {
            Vozilo = repo.FindAll().ToList();

        }
    }
}