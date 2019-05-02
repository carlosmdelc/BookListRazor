using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRazor.Pages.BookList
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDBContext _context;

        public EditModel(ApplicationDBContext context)
        {
            _context = context;
        }

        [TempData]
        public string Message { get; set; }

        [BindProperty]
        public Book Book { get; set; }

        public async Task OnGet(int id)
        {
            Book = await _context.Books.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
                return RedirectToPage();
            
                var bookInfoToEdit = await _context.Books.FindAsync(Book.Id);
                bookInfoToEdit.Name = Book.Name;
                bookInfoToEdit.Author = Book.Author;
                bookInfoToEdit.ISBN = Book.ISBN;

                await _context.SaveChangesAsync();
                
                Message = "Book information has been updated successfully.";

                return RedirectToPage("Index");
        }
    }
}