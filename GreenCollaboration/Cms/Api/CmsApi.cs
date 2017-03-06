using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using GreenCollaboration.Models;
using GreenCollaboration.ViewModels;
using System.Data.Entity;
using System.Web.Mvc;


public class CmsApi
{
    private static ApplicationDbContext _context;

    public CmsApi(ApplicationDbContext context)
    {
        _context = context;
    }
    //Return As MvcHtmlString  *
    public static MvcHtmlString GetProperty(PageViewModel page, string alias)
    {
        return new MvcHtmlString(GetPropertyByAlias(page.PageId, alias));
    }
    // GetProperty Alias *
    private static dynamic GetPropertyByAlias(int id, string alias)
    {
        return _context.CmsProperties.FirstOrDefault(p => p.Alias == alias && p.PageId == id)?.Value;
    }


    //return IEnumarble af<dynamic> GetPages

    public static IEnumerable<dynamic> Getpages()
    {

        return pages();
    }

    //return RootPage
    public static dynamic GetRootPage()
    {
        var root = pages()
            .FirstOrDefault(p => p.Url == "/");
        return (dynamic)root;
    }

    // return PageId
    public static dynamic GetPageById(int id)
    {
        var page = pages()
               .FirstOrDefault(p => p.PageId == id);
        return GetViewModel(page);
    }

    // return PageIByAlias
    public static dynamic GetPageByAlieas(string alias)
    {
        var page = pages()
               .FirstOrDefault(p => p.Alias == alias);
        return GetViewModel(page);
    }


    // Return Dynamic Current Page
    public dynamic GetcurrentPage(string url)
    {
        if (url == null)
        {
            var currentPage = pages()

                .FirstOrDefault(page => page.Url == "/");
            var viewModel = GetViewModel(currentPage);
            return (dynamic)viewModel;
        }
        else
        {
            var currentPage = pages()
                .FirstOrDefault(page => page.Url == "/" + url);
            var viewModel = GetViewModel(currentPage);
            return (dynamic)viewModel;
        }
    }

    //Private Get Pages
    private static IEnumerable<dynamic> pages()
    {
        var pagelist = new List<dynamic>();
        if (!_context.CmsPages.Any())
        {
            return pagelist;
        }
        pagelist.AddRange(_context.CmsPages
          .Include(p => p.Children)
          .Include(x => x.Properties)
          .Include(x => x.Template)
          .Include(p => p.Parent)
          .Where(p => p.Level > 0)
          .ToList()
          );
        return pagelist;
    }

    //Create Vm from CmsPage
    private static PageViewModel GetViewModel(CmsPage currentPage)
    {
        //var listprops = _context.CmsProperties.Cast<dynamic>().ToList();
        var vm = new PageViewModel
        {
            PageId = currentPage.PageId,
            Alias = currentPage.Alias,
            IconName = currentPage.IconName,
            Template = currentPage.Template.Name,
            ShowInMenu = currentPage.ShowInMenu,
            CreateDate = currentPage.CreateDate,
            Level = currentPage.Level,
            Order = currentPage.Order,
            Parent = currentPage.Parent,
            Url = currentPage.Url

            //Properties
            //Children
        };
        return vm;
    }

}