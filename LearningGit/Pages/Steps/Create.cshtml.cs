using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LearningGit;

namespace LearningGit.Pages.Steps
{
    public class CreateModel : PageModel
    {
        private readonly LearningGit.AppDbContext _context;

        public CreateModel(LearningGit.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int? titleId)
        {
        ViewData["TitleID"] = new SelectList(_context.Titles, "TitleID", "TitleText", titleId);
            return Page();
        }

        [BindProperty]
        public Step Step { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Steps.Add(Step);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index", new { titleId = Step.TitleID });
        }
    }
}
