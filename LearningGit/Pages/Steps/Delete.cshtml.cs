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
    public class DeleteModel : PageModel
    {
        private readonly LearningGit.AppDbContext _context;

        public DeleteModel(LearningGit.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Step = await _context.Steps.FindAsync(id);

            if (Step != null)
            {
                _context.Steps.Remove(Step);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
