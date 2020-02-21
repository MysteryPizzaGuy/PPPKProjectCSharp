using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PPKProjekt.Models;
using PPKProjekt.Repository;

namespace PPKProjekt.Pages.CRUDPutniNalog
{
    public class IndexModel : PageModel
    {


        private readonly IPutniNalogRepository repo;
        public enum NalogState { Aktivni,Buduci,Zatvoreni }




        [BindProperty]
        public NalogState? SelectedState { get; set; }
        public IList<SelectListItem> SelectedStateList { get; set; } = new List<SelectListItem>();




        public IndexModel()
        {
            repo = new PutniNalogRepository();
        }
        public void OnPost()
        {
            repo.InsertTestCase();
            PutniNalog = repo.FindAll().ToList();


        }

        public IList<PutniNalog> PutniNalog { get; set; }

        public void OnGet(NalogState? nowState)
        {
            
            SelectedStateList.Add(new SelectListItem() { Text = "All", Value = "All" });
            SelectedStateList.Add(new SelectListItem() { Text = NalogState.Aktivni.ToString(), Value = NalogState.Aktivni.ToString() });
            SelectedStateList.Add(new SelectListItem() { Text = NalogState.Buduci.ToString(), Value = NalogState.Buduci.ToString() });
            SelectedStateList.Add(new SelectListItem() { Text = NalogState.Zatvoreni.ToString(), Value = NalogState.Zatvoreni.ToString() });
            if (nowState == NalogState.Aktivni)
            {
                PutniNalog = repo.FindBetweenDates(DateTime.Now.AddDays(-1), DateTime.Now).ToList();
            }
            else if (nowState == NalogState.Buduci)
            {
                PutniNalog = repo.FindBetweenDates(DateTime.Now.AddDays(1), System.Data.SqlTypes.SqlDateTime.MaxValue.Value).ToList();

            }
            else if (nowState == NalogState.Zatvoreni)
            {
                PutniNalog = repo.FindBetweenDates(System.Data.SqlTypes.SqlDateTime.MinValue.Value, DateTime.Now.AddDays(-1)).ToList();
            }
            else
            {
                PutniNalog = repo.FindAll().ToList();
            }
            SelectedState = nowState;

        }
        public IActionResult OnPostFilterGenerated()
        {
            return RedirectToPage("./Index", new { nowState=SelectedState });
        }

    }
}