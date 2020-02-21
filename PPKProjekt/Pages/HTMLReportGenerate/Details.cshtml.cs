using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PPKProjekt.EntityFramework;

namespace PPKProjekt.Pages.HTMLReportGenerate
{
    public class DetailsModel : PageModel
    {
        private readonly PPKProjekt.EntityFramework.VehicleControlContext _context;

        public DetailsModel(PPKProjekt.EntityFramework.VehicleControlContext context)
        {
            _context = context;
        }

        public TblVozilo TblVozilo { get; set; }

        [BindProperty]
        public double TotalKM { get; set; }
        [BindProperty]
        public double AverageSpeed { get; set; }
        [BindProperty]
        public List<TblServis> Servisi { get; set; }


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TblVozilo =  _context.TblVozilo.Include(x=>x.TblPutniNalog).ThenInclude(y=> y.TblRuta).FirstOrDefault(m => m.Idvozilo == id);

            var allPN = TblVozilo.TblPutniNalog;
            double total = 0;
            foreach (var pn in allPN)
            {
               total+= (double)pn.TblRuta.Sum(x => x.PrijedeniKm);
            }
            TotalKM = (int)TblVozilo.InicijalniKm + total;
            double kms = 0;
            int count = 0;
            foreach (var pn in allPN)
            {
                kms += (double)pn.TblRuta.Average(x => x.ProsjecniKmh);
                count++;
            }

            AverageSpeed = (kms/count);

            Servisi =  TblVozilo.TblServis.ToList();



            if (TblVozilo == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
