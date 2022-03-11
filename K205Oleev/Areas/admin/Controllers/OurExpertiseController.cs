using DataAccess;
using Entities;
using Helper.Methods;
using K205Oleev.Areas.admin.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services;

namespace K205Oleev.Areas.admin.Controllers
{

    [Area("admin")]
    public class OurExpertiseController : Controller
    {
        private readonly OurExpertiseServices _services;
        private IWebHostEnvironment _environment;

        public OurExpertiseController(OurExpertiseServices services, IWebHostEnvironment environment)
        {
            _environment = environment;
            _services = services;
        }

        public IActionResult Index()
        {
            var ourexpertise = _services.GetAll();

            return View(ourexpertise);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(List<string> Title, List<string> Description, List<string> SubTitle, List<string> SubDescription, List<string> LangCode, List<string> SEO, string PhotoURL, string Icon)
        {
           

            

            for (int i = 0; i < Title.Count; i++)
            {
                _services.CreateOurExpertise(Title[i],Description[i], SubTitle[i], SubDescription[i], LangCode[i], SEO[i], PhotoURL,Icon);
            }


            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            //EditVM editVM = new()
            //{
            //    OurExpertiseLanguages = _context.OurExpertiseLanguages.Include(x => x.OurExpertise).Where(x => x.OurExpertiseID == id).ToList(),
            //    OurExpertise = _context.OurExpertises.FirstOrDefault(x => x.ID == id.Value)
            //};

            //return View(editVM);
            return null;
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int OurExpertiseID, List<int> LangID, List<string> Title, List<string> Description, List<string> SubTitle, List<string> SubDescription, List<string> LangCode, string PhotoURL, string Icon)
        {
            //for (int i = 0; i < Title.Count; i++)
            //{
            //    SEO seo = new();

            //    OurExpertiseLanguage ourExpertiseLanguage = new()
            //    {
            //        ID = LangID[i],
            //        Title = Title[i],
            //        Description = Description[i],
            //        SubTitle = SubTitle[i],
            //        SubDescription = SubDescription[i],
            //        SEO = seo.SeoURL(Title[i]),
            //        LangCode = LangCode[i],
            //        OurExpertiseID = OurExpertiseID
            //    };
            //    var updatedEntity = _context.Entry(ourExpertiseLanguage);
            //    updatedEntity.State = EntityState.Modified;

            //}
            //_context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }

}
