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
    public class IndexModel : PageModel
    {

        private IRutaRepository rutarepo;

        [BindProperty]
        public int pnID { get; set; }

        public IndexModel()
        {
            this.rutarepo = new RutaRepository();
            
        }

        public IList<Ruta> Ruta { get;set; }


        public void OnGet(int? id)
        {
            Ruta = rutarepo.FindAll().Where(x => x.PutniNalog.IDPutniNalog == id).ToList();
            pnID = (int)id;
        }
    }
}
