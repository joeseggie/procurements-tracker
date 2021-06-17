﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProcurementTracker.Data;
using ProcurementTracker.Models;

namespace ProcurementTracker.Pages.Procurements
{
    public class DetailsModel : PageModel
    {
        private readonly ProcurementTracker.Data.ProcurementTrackerContext _context;

        public DetailsModel(ProcurementTracker.Data.ProcurementTrackerContext context)
        {
            _context = context;
        }

        public Procurement Procurement { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Procurement = await _context.Procurement.FirstOrDefaultAsync(m => m.Id == id);

            if (Procurement == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
