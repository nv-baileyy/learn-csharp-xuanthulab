using Razor_PageModel_ModelBiding.Models;
using System.Collections.Generic;
using System.Linq;

namespace Razor_PageModel_ModelBiding.Services
{
    public class ContactServices
    {
        private List<Contact> contacts { get; }

        public ContactServices()
        {
            contacts = new List<Contact>
            {
                new Contact(){ Id=1, Name = "Thuy Hang", Number = "01234566", Email = "hangabc@mail.com"},
                new Contact(){Id=3,Name = "Van Hai", Number = "01234523466", Email = "hai@mail.com"},
                new Contact(){Id=2,Name = "ITS", Number = "01234566", Email = "its-global@mail.com"}
            };
        }

        public List<Contact> ListContacts() => contacts;

        public Contact FindbyId(int id)
        {
            var contact = contacts.Where(c => c.Id == id).SingleOrDefault();
            return contact;
        }
    }
}