using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using razor08.efcore.Data;

namespace razor_ef.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly MyBlogContext myBlogContext;

    public IndexModel(ILogger<IndexModel> logger, MyBlogContext _myContext)
    {
        _logger = logger;
        myBlogContext = _myContext;
    }

    public void OnGet()
    {
        var post = (from a in myBlogContext.Article
                    orderby a.PublishDate descending
                    select a).ToList();
        Console.WriteLine(post);
        ViewData["posts"] = post;
    }
}
