using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using MovieStarSignalR.Hubs;
using MovieStarSignalR.Models;

namespace MovieStarSignalR.Pages.List
{
    public class CreateModel : PageModel
    {
        private readonly MovieStarSignalR.Models.PE_PRN_Fall2023B1Context _context;
        private readonly IHubContext<SignalRServer> _signalRHub;

        public CreateModel(MovieStarSignalR.Models.PE_PRN_Fall2023B1Context context,
            IHubContext<SignalRServer> signalRHub)
        {
            _context = context;
            _signalRHub = signalRHub;
        }

        public IActionResult OnGet()
        {
        ViewData["DirectorId"] = new SelectList(_context.Directors, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Movie Movie { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            Console.WriteLine(Movie);
            if (!ModelState.IsValid || _context.Movies == null || Movie == null)
            {
                // Log ModelState errors
                foreach (var modelStateEntry in ModelState.Values)
                {
                    foreach (var error in modelStateEntry.Errors)
                    {
                        Console.WriteLine(error.ErrorMessage);
                    }
                }

                return Page();
            }
            
            _context.Movies.Add(Movie);
            await _context.SaveChangesAsync();
            await _signalRHub.Clients.All.SendAsync("LoadMovies");
            return RedirectToPage("./Index");
        }
    }
}
