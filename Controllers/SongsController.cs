using FavoriteSongs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FavoriteSongs.Controllers
{
    public class SongsController : Controller
    {

        private readonly MusicContext _context;

        public SongsController(MusicContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));  // Проверка на null
        }

        // Метод для отображения списка песен
        public async Task<IActionResult> Index()
        {
            var songs = await _context.Songs
            .Include(s => s.SurveyResults)  // Подгружаем связанные голоса
            .ToListAsync();

            var viewModel = songs.Select(s => new SongWithVotes
            {
                Id = s.Id,
                Title = s.Title,
                Artist = s.Artist,
                VoteCount = s.SurveyResults.Count()
            }).ToList();
            // Здесь передаём правильную модель в представление
            return View(viewModel);
        }

        
    }
    }
