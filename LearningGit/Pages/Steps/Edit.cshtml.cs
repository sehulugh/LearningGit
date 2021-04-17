using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LearningGit;

namespace LearningGit.Pages.Steps
{
    public class EditModel : PageModel
    {
        private readonly LearningGit.AppDbContext _context;

        public EditModel(LearningGit.AppDbContext context)
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
           ViewData["TitleID"] = new SelectList(_context.Titles, "TitleID", "TitleID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Step).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StepExists(Step.StepID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index", new { titleId = Step.TitleID});
        }

        private bool StepExists(int id)
        {
            return _context.Steps.Any(e => e.StepID == id);
        }
    }
}
