using LinkedinBot.DTO;
using LinkedinBot.Models;
using LinkedinBot.Service;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LinkedinBot.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILinkedinScraper scraper;

        public HomeController(ILogger<HomeController> logger, ILinkedinScraper scraper)
        {
            _logger = logger;
            this.scraper = scraper;
        }

        public IActionResult Index()
        {
            return View(new RequestParams()
            {
                LinkToSearchRecruiters = "https://www.linkedin.com/search/results/people/?geoUrn=%5B%22106057199%22%5D&heroEntityKey=urn%3Ali%3Aautocomplete%3A290312632&keywords=tech%20recruiter&network=%5B%22S%22%2C%22O%22%5D&origin=FACETED_SEARCH&position=0&searchId=4eac391a-1860-44cc-b91a-6738f943e00b&sid=9Zp&talksAbout=%5B%22hiring%22%5D"
            });
        }

        public IActionResult DoIt(RequestParams request)
        {
            scraper.LetsDoItHardWork(request);
            return RedirectToAction("Index", "Recruiters");
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