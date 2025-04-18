using FavoriteSongs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace FavoriteSongs.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        //public IActionResult Index()
        //{
        //    return View();
        //}

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}

        private readonly MusicContext _context;

        public HomeController(MusicContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var songs = await _context.Songs
                .Include(s => s.SurveyResults)
                .ToListAsync();

            var viewModel = songs.Select(s => new SongWithVotes
            {
                Id = s.Id,
                Title = s.Title,
                Artist = s.Artist,
                VoteCount = s.SurveyResults.Count()
            }).ToList();

            return View(viewModel);
        }
    }
}
