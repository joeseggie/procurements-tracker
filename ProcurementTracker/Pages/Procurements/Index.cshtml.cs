using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProcurementTracker.Data;
using ProcurementTracker.Models;
using ProcurementTracker.Shared;

namespace ProcurementTracker.Pages.Procurements
{
    public class IndexModel : PageModel
    {
        private readonly ProcurementTracker.Data.ProcurementTrackerContext _context;

        public IndexModel(ProcurementTracker.Data.ProcurementTrackerContext context)
        {
            _context = context;
        }

        public IList<Procurement> Procurement { get;set; }

        [BindProperty]
        public string SearchText { get; set; }

        public async Task OnGetAsync()
        {
            Procurement = await _context.Procurement.ToListAsync();
        }

        public string DisplayProcurementPlan(bool isPlanned)
        {
            return isPlanned ? "PROCUREMENT PLAN" : "BUDGET";
        }

        public async Task OnPostSearch()
        {
            if (!string.IsNullOrEmpty(SearchText))
            {
                var keywordsToSearchFor = SearchText.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

                string queryFilter = string.Empty;
                if (keywordsToSearchFor != null || keywordsToSearchFor.Count > 0)
                {
                    int keywordsCount = keywordsToSearchFor.Count;

                    StringBuilder queryFilterBuilder = new StringBuilder().Clear();
                    queryFilterBuilder.Append("WHERE ");

                    for (int count = 0; count < keywordsCount; count++)
                    {
                        if ((count + 1) != keywordsCount)
                        {
                            queryFilterBuilder.Append($"Subject LIKE '%{keywordsToSearchFor[count]}%' OR ");
                        }
                        else
                        {
                            queryFilterBuilder.Append($"Subject LIKE '%{keywordsToSearchFor[count]}%'");
                        }
                    }

                    queryFilter = queryFilterBuilder.ToString();
                }

                Procurement = await _context.Procurement
                                            .FromSqlRaw($"SELECT * FROM Procurement {queryFilter};")
                                            .ToListAsync();
            }
        }
    }
}
