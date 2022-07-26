using DeckOfCardsAPILab.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;

namespace DeckOfCardsAPILab.Controllers
{
    public class HomeController : Controller
    {
        DeckDAL deckDAL = new DeckDAL();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Draw()
        {
            DeckModel result = deckDAL.DrawCards();
            {
                if (result.remaining >= 1)
                {
                    return View(result);
                }
                else
                {
                    deckDAL.ShuffleCards();
                    return View(result);
                }
            }

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}