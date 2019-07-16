using AddressBook2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace AddressBook2.Pages.Addresses {
    [Authorize]
    public class IndexModel : PageModel {
        private readonly Data.ApplicationDbContext _context;
        public string userId;

        public IndexModel(Data.ApplicationDbContext context) {
            _context = context;
        }

        public IList<Contact> Contact { get; set; }

        //public async Task OnGetAsync() {
        //    Contacts = await _context.Contact.ToListAsync();
        //}

        public void OnGet() {
            userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            Contact = GetContacts(userId);
        }

        public IList<Contact> GetContacts(string id) {
            var query = from contact in _context.Contact
                        where contact.ForeignKey == id
                        select contact;
            return query.ToList();
        }
    }
}
