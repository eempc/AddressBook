using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AddressBook2.Data;
using AddressBook2.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace AddressBook2.Pages.Addresses {
    [Authorize]
    public class IndexModel : PageModel {
        private readonly AddressBook2.Data.ApplicationDbContext _context;
        public string userId;

        public IndexModel(AddressBook2.Data.ApplicationDbContext context) {
            _context = context;
        }

        public IList<Contact> Contacts { get; set; }

        //public async Task OnGetAsync() {
        //    Contacts = await _context.Contact.ToListAsync();
        //}

        public void OnGet() {
            userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            Contacts = GetContacts(userId);
        }

        public IList<Contact> GetContacts(string id) {
            var query = from contact in _context.Contact
                        where contact.ForeignKey == id
                        select contact;
            return query.ToList();
        }
    }
}
