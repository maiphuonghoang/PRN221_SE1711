using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MovieStarSignalR.Models;

namespace MovieStarSignalR.Pages.List
{
    public class IndexModel : PageModel
    {
        private readonly MovieStarSignalR.Models.PE_PRN_Fall2023B1Context _context;

        public IndexModel(MovieStarSignalR.Models.PE_PRN_Fall2023B1Context context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Movies != null)
            {
                Movie = await _context.Movies
                .Include(m => m.Director).ToListAsync();
            }
        }
    }
}
