using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using Cards.Models;

namespace Cards.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //asynchronous controller actions return tasks
        //the task provides in this case the IAction Result (the view)
        //when everything's done
        public async Task<IActionResult> Index()
        {

            var client = new HttpClient();
            client.BaseAddress = new Uri("https://deckofcardsapi.com");
            client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (compatible; GrandCircus/1.0)");


            var response = await client.GetAsync("api/deck/new/shuffle/?deck_count=1");

            var cards = await response.Content.ReadAsAsync<CardPlay>();

            return View(cards);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
