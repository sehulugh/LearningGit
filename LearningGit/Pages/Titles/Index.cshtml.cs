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
    public class IndexModel : PageModel
    {
        private readonly LearningGit.AppDbContext _context;

        public IndexModel(LearningGit.AppDbContext context)
        {
            _context = context;
        }

        public IList<Title> Title { get;set; }

        public async Task OnGetAsync()
        {
            Title = await _context.Titles.ToListAsync();
        }
    }
}
