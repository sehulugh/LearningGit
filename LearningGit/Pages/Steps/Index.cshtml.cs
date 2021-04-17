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
    public class IndexModel : PageModel
    {
        private readonly LearningGit.AppDbContext _context;

        public IndexModel(LearningGit.AppDbContext context)
        {
            _context = context;
        }

        public IList<Step> Step { get;set; }

        public async Task OnGetAsync(int? titleId)
        {
            if (titleId == null)
            {
                Step = await _context.Steps.Include(s => s.Title).ToListAsync();
            }
            else
            {
                Step = await _context.Steps.Include(s => s.Title).Where(x=>x.TitleID == titleId).ToListAsync();

                ViewData["TitleData"] =   _context.Titles.Find(titleId);
            }

        }
    }
}
