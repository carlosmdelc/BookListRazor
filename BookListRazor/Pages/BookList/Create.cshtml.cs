using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRazor.Pages.BookList
{
    public class CreateModel : PageModel
    {
        [TempData]
        public string Message { get; set; }

        [BindProperty]
        public Book Book { get; set; }

        private readonly ApplicationDBContext _context;

        public CreateModel(ApplicationDBContext context)
        {
            _context = context;
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            // It is already bind when using BindProperty
            _context.Books.Add(Book);
            await _context.SaveChangesAsync();

            // Since you are going to redirect to Index and that page has the same Message prop, you don't need to generate a new one.
            Message = "Book has been created successfully";

            return RedirectToPage("Index");
        }
    }
}