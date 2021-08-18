using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        [BindProperty]
        public string ProcurementMethod { get; set; }

        [BindProperty]
        public string ProcurementStatus { get; set; }

        public List<SelectListItem> ProcurementStatuses { get; set; } = ChoicesList.Create<ProcurementStatus>();

        public List<SelectListItem> ProcurementMethods { get; set; } = ChoicesList.Create<ProcurementMethod>();

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
            string queryFilter = string.Empty;
            StringBuilder queryFilterBuilder = new StringBuilder().Clear();

            if (!string.IsNullOrEmpty(SearchText))
            {
                queryFilterBuilder.Append(" WHERE ");
                var keywordsToSearchFor = SearchText.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

                if (keywordsToSearchFor != null || keywordsToSearchFor.Count > 0)
                {
                    int keywordsCount = keywordsToSearchFor.Count;

                    for (int count = 0; count < keywordsCount; count++)
                    {
                        if ((count + 1) != keywordsCount)
                        {
                            queryFilterBuilder.Append($"(Subject LIKE '%{keywordsToSearchFor[count]}%' OR ");
                        }
                        else
                        {
							if (keywordsCount > 1)
								queryFilterBuilder.Append($"Subject LIKE '%{keywordsToSearchFor[count]}%')");
                            else
                                queryFilterBuilder.Append($"Subject LIKE '%{keywordsToSearchFor[count]}%'");
                        }
                    }

                    queryFilter += queryFilterBuilder.ToString();
                    queryFilterBuilder.Clear();
                }
            }

			if (!string.IsNullOrEmpty(ProcurementStatus) && ProcurementStatus != "Choose...")
			{
				if (!string.IsNullOrEmpty(queryFilter))
				{
                    queryFilterBuilder.Append($" AND Status = '{ProcurementStatus}'");
				}
				else
                {
                    queryFilterBuilder.Append($" WHERE Status = '{ProcurementStatus}'");
                }

                queryFilter += queryFilterBuilder.ToString();
                queryFilterBuilder.Clear();
			}

            Procurement = await _context.Procurement
                                        .FromSqlRaw($"SELECT * FROM Procurement{queryFilter};")
                                        .ToListAsync();
        }

        public async Task OnPostClearAsync()
        {
            SearchText = string.Empty;
            ProcurementStatus = "Choose...";
            ProcurementMethod = "Choose...";

            Procurement = await _context.Procurement.ToListAsync();
        }
    }
}
