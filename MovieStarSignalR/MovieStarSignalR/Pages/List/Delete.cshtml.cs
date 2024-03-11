using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using MovieStarSignalR.Hubs;
using MovieStarSignalR.Models;

namespace MovieStarSignalR.Pages.List
{
    public class DeleteModel : PageModel
    {
        private readonly MovieStarSignalR.Models.PE_PRN_Fall2023B1Context _context;
        private readonly IHubContext<SignalRServer> _signalRHub;

        public DeleteModel(MovieStarSignalR.Models.PE_PRN_Fall2023B1Context context,
            IHubContext<SignalRServer> signalRHub)
        {
            _context = context;
            _signalRHub = signalRHub;
        }

        [BindProperty]
      public Movie Movie { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Movies == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies.FirstOrDefaultAsync(m => m.Id == id);

            if (movie == null)
            {
                return NotFound();
            }
            else 
            {
                Movie = movie;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Movies == null)
            {
                return NotFound();
            }
            var movie = await _context.Movies.Include(m => m.MovieStars).Include(m=>m.Genres).Include(m=>m.Schedules).FirstAsync(m=>m.Id==id);
            // Set foreign key properties to null for the Schedules collection

            if (movie != null)
            {
                Movie = movie;
                Movie.MovieStars.Clear();
                Movie.Genres.Clear();
                Movie.Schedules.Clear();
                _context.Movies.Remove(Movie);
                await _context.SaveChangesAsync();
                await _signalRHub.Clients.All.SendAsync("LoadMovies");
            }

            return RedirectToPage("./Index");
        }
    }
}
