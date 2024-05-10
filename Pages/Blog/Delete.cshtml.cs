using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using razor08.efcore;

namespace razor_ef.Pages_Blog
{
    public class DeleteModel : PageModel
    {
        private readonly razor08.efcore.MyBlogContext _context;

        public DeleteModel(razor08.efcore.MyBlogContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Article Article { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return Content("Khong tim thay bai viet");
            }

            var article = await _context.Article.FirstOrDefaultAsync(m => m.ID == id);

            if (article == null)
            {
                return Content("Khong tim thay bai viet");
            }
            else
            {
                Article = article;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return Content("Khong tim thay bai viet");
            }

            var article = await _context.Article.FindAsync(id);
            if (article != null)
            {
                Article = article;
                _context.Article.Remove(Article);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
