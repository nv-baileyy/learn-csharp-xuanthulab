using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Razor_PageModel_ModelBiding.Models;
using Razor_PageModel_ModelBiding.Services;
using System.Collections.Generic;
using System.Reflection;

namespace Razor_PageModel_ModelBiding.Pages
{
    public class ContactRequestModel : PageModel
    {
        public string UserId { get; set; }
        private readonly ILogger _logger;

        public ContactServices _contacts;

        // inject dich vu vao PageModel
        public ContactRequestModel(ILogger<ContactRequestModel> logger, ContactServices contacts)
        {
            _logger = logger;
            _contacts = contacts;
            _logger.LogInformation("Init contact");
        }

        public List<Contact> contacts;
        public Contact contact;

        // OnGet, OnPost, OnGetAbc... -> Handler
        // => return Void/IActionResult

        // value id: tim tren asp-route-id hoac tim tren nguon du lieu duoc gui den
        public void OnGet(int? id)
        {
            //var v_id = Request.RouteValues["id"] ?? "0";
            var v_id = id ?? -1;
            if (v_id >= 0)
                contact = _contacts.FindbyId(v_id);
            else contacts = _contacts.ListContacts();
            ViewData["TT"] = $"So luong contact: {v_id}";
        }
    }
}