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
    public class CaseStudyController : Controller
    {

        private readonly CaseStudyServices _services;
        private IWebHostEnvironment _environment;

        public CaseStudyController(CaseStudyServices services, IWebHostEnvironment environment)
        {
            _environment = environment;
            _services = services;
        }

        public IActionResult Index()
        {
            var caseStudy = _services.GetAll();


            return View(caseStudy);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(List<string> Title, List<string> LangCode, List<string> SEO, string PhotoURL)
        {


            for (int i = 0; i < Title.Count; i++)
            {
                _services.CreateCaseStudy(Title[i], LangCode[i], SEO[i], PhotoURL);
            }



            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            //EditVM editVM = new()
            //{
            //    CaseStudyLanguages = _context.CaseStudyLanguages.Include(x => x.CaseStudy).Where(x => x.CaseStudyID == id).ToList(),
            //    CaseStudy = _context.CaseStudies.FirstOrDefault(x => x.ID == id.Value)
            //};

            //return View(editVM);
            return null;
        }


        [HttpPost]
        public async Task<IActionResult> Edit(int CaseStudyID, List<int> LangID, List<string> Title, List<string> LangCode, string PhotoURL)
        {
            //for (int i = 0; i < Title.Count; i++)
            //{
            //    SEO seo = new();

            //    CaseStudyLanguage caseStudyLanguage = new()
            //    {
            //        ID = LangID[i],
            //        Title = Title[i],
            //        SEO = seo.SeoURL(Title[i]),
            //        LangCode = LangCode[i],
            //        CaseStudyID = CaseStudyID
            //    };
            //    var updatedEntity = _context.Entry(caseStudyLanguage);
            //    updatedEntity.State = EntityState.Modified;

            //}
            //_context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
