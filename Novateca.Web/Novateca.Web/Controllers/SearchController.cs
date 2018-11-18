using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Novateca.Web.Models;

namespace Novateca.Web.Controllers
{
    public class SearchController : Controller
    {

        private readonly NovatecaDbContext _context;

        public SearchController(NovatecaDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Index(string objetoPesquisado)
        {
            var bookResults  = _context.Book.Where(x => x.TitleMain.Contains(objetoPesquisado)).
               Select(b => new Book
               {
                   BookID = b.BookID,
                   TitleMain = b.TitleMain,
                   AvatarImage = b.AvatarImage
               }).ToList();
            ViewBag.BookResults = bookResults;
            var multimediaResults = _context.Multimedia.Where(x => x.TitleMain.Contains(objetoPesquisado)).
             Select(n => new Multimedia
             {
                 MultimediaID = n.MultimediaID,
                 TitleMain = n.TitleMain,
                 AvatarImage = n.AvatarImage
             }).ToList();
            ViewBag.multimediaResults = multimediaResults;
            var newspaperResults = _context.Newspapers.Where(x => x.TitleMain.Contains(objetoPesquisado)).
              Select(n => new Newspaper
              {
                  NewspaperID = n.NewspaperID,
                  TitleMain = n.TitleMain,
                  AvatarImage = n.AvatarImage
              }).ToList();
            ViewBag.NewspaperResults = newspaperResults;
            //var bookResults = _context.Book.Where(x => x.TitleMain.Contains(objetoPesquisado)).Select(s => s.TitleMain).ToList();
            //ViewBag.BookResults = bookResults;
            //var newspaperResults = _context.Newspapers.Where(x => x.TitleMain.Contains(objetoPesquisado)).Select(s => s.TitleMain).ToList();
            //ViewBag.NewspaperResults = newspaperResults;
            //var multimediaResults = _context.Multimedia.Where(x => x.TitleMain.Contains(objetoPesquisado)).Select(s => s.TitleMain).ToList();
            //ViewBag.multimediaResults = multimediaResults;
            return View("Search");
            
        }

    }
}