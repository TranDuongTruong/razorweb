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
    public class IndexModel : PageModel
    {
        private readonly razor08.efcore.MyBlogContext _context;

        public IndexModel(razor08.efcore.MyBlogContext context)
        {
            _context = context;
        }
        public const int ITEMS_PER_PAGE = 100;
        [BindProperty(SupportsGet = true, Name = "p")]
        public int currentpage { get; set; }
        public int countpages { get; set; }
        public IList<Article> Article { get; set; } = default!;

        public async Task OnGetAsync(string SearchString)
        {
            //Article = await _context.Article.ToListAsync();
            int totalArticle = await _context.Article.CountAsync();
            countpages = (int)Math.Ceiling((double)totalArticle / ITEMS_PER_PAGE);
            if (currentpage < 1) currentpage = 1;
            if (currentpage > countpages) currentpage = countpages;

            var qr = (from a in _context.Article orderby a.PublishDate descending select a).Skip((currentpage - 1) * ITEMS_PER_PAGE).Take(ITEMS_PER_PAGE);
            if (!string.IsNullOrEmpty(SearchString))
            {
                Article = await qr.Where(a => a.Title.Contains(SearchString)).ToListAsync();
            }
            else
            {
                Article = await qr.ToListAsync();

            }

        }
    }
}
