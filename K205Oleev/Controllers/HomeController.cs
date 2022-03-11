using System.Diagnostics;
using Entities;
using K205Oleev.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace K205Oleev.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AboutServices _aboutServices;
        private readonly InfoServices _infoServices;
        private readonly OurServiceServices _ourserviceServices;

        public HomeController(ILogger<HomeController> logger, AboutServices aboutServices, InfoServices infoServices, OurServiceServices ourserviceServices)
        {
            _logger = logger;
            _aboutServices = aboutServices;
            _infoServices = infoServices;
            _ourserviceServices = ourserviceServices;
        }

        public IActionResult Index()
        {
            var langCode = Request.Cookies["Language"];
            HomeVM homeVM = new()
            {
                AboutLanguages = _aboutServices.GetAll(langCode),
                InfoLanguages = _infoServices.GetAll(langCode),
                OurServiceLanguages = _ourserviceServices.GetAll(langCode),
                InfoLanguage = _infoServices.GetOne()

            }; 
            return View(homeVM);
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