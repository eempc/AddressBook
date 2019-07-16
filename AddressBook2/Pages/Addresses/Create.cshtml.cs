using AddressBook2.Data;
using AddressBook2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AddressBook2.Pages.Addresses {
    [Authorize]
    public class CreateModel : PageModel {
        private readonly ApplicationDbContext _context;

        // Attempts to find out who is the logged in user and their details
        public string userId;
        public string userEmail;

        public CreateModel(AddressBook2.Data.ApplicationDbContext context) {
            _context = context;
        }

        public IActionResult OnGet() {
            userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            userEmail = User.FindFirst(ClaimTypes.Name)?.Value;
            return Page();
        }

        [BindProperty]
        public Contact Contact { get; set; }

        public async Task<IActionResult> OnPostAsync() {
            if (!ModelState.IsValid) {
                userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                userEmail = User.FindFirst(ClaimTypes.Name).Value;
                return Page();
            }

            _context.Contact.Add(Contact);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}