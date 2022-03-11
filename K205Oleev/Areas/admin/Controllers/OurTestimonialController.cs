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
    public class OurTestimonialController : Controller
    {
        private readonly OurTestimonialServices _services;
        private IWebHostEnvironment _environment;

        public OurTestimonialController(OurTestimonialServices services, IWebHostEnvironment environment)
        {
            _environment = environment;
            _services = services;
        }

        public IActionResult Index()
        {
            var ourtestimonial = _services.GetAll();
            return View(ourtestimonial);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(List<string> Title, List<string> Description, List<string> Name, List<string> Profession, List<string> LangCode, List<string> SEO, string PhotoURL)
        {
            

            for (int i = 0; i < Title.Count; i++)
            {
                _services.CreateOurTestimonial(Title[i],Description[i], Name[i], Profession[i], LangCode[i], SEO[i], PhotoURL);
            }



            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            //EditVM editVM = new()
            //{
            //    OurTestimonialLanguages = _context.OurTestimonialLanguages.Include(x => x.OurTestimonial).Where(x => x.OurTestimonialID == id).ToList(),
            //    OurTestimonial = _context.OurTestimonials.FirstOrDefault(x => x.ID == id.Value)
            //};

            //return View(editVM);
            return null;
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int OurTestimonialID, List<int> LangID, List<string> Title, List<string> Description, List<string> Name, List<string> Profession, List<string> LangCode, string PhotoURL)
        {
            //for (int i = 0; i < Title.Count; i++)
            //{
            //    SEO seo = new();

            //    OurTestimonialLanguage ourTestimonialLanguage = new()
            //    {
            //        ID = LangID[i],
            //        Title = Title[i],
            //        Description = Description[i],
            //        SEO = seo.SeoURL(Title[i]),
            //        LangCode = LangCode[i],
            //        OurTestimonialID = OurTestimonialID
            //    };
            //    var updatedEntity = _context.Entry(ourTestimonialLanguage);
            //    updatedEntity.State = EntityState.Modified;

            //}
            //_context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
