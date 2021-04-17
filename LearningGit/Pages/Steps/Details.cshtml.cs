using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LearningGit;

namespace LearningGit.Pages.Steps
{
    public class DetailsModel : PageModel
    {
        private readonly LearningGit.AppDbContext _context;

        public DetailsModel(LearningGit.AppDbContext context)
        {
            _context = context;
        }

        public Step Step { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Step = await _context.Steps
                .Include(s => s.Title).FirstOrDefaultAsync(m => m.StepID == id);

            if (Step == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
