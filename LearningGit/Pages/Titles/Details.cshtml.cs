using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LearningGit;

namespace LearningGit.Pages.Titles
{
    public class DetailsModel : PageModel
    {
        private readonly LearningGit.AppDbContext _context;

        public DetailsModel(LearningGit.AppDbContext context)
        {
            _context = context;
        }

        public Title Title { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Title = await _context.Titles.FirstOrDefaultAsync(m => m.TitleID == id);

            if (Title == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
