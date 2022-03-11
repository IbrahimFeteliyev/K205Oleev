using Microsoft.AspNetCore.Mvc;
using Services;

namespace K205Oleev.Areas.admin.Controllers
{
    [Area("admin")]

    public class CountDownController : Controller
    {
        private readonly CountDownServices _services;


        public CountDownController(CountDownServices services)
        {
            _services = services;
        }

        public IActionResult Index()
        {
            var countdown = _services.GetAll();

            return View(countdown);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(List<string> Title, List<string> LangCode, List<string> SEO, int Count)
        {
            

            for (int i = 0; i < Title.Count; i++)
            {
                _services.CreateCountDown(Title[i], LangCode[i], SEO[i], Count);
            }



            return RedirectToAction(nameof(Index));
        }



        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            //EditVM editVM = new()
            //{
            //    CountDownLanguages = _context.CountDownLanguages.Include(x => x.CountDown).Where(x => x.CountDownID == id).ToList(),
            //    CountDown = _context.CountDowns.FirstOrDefault(x => x.ID == id.Value)
            //};

            //return View(editVM);
            return null;
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int CountDownID, List<int> LangID, List<string> Title,  List<string> LangCode, int Count)
        {
            //for (int i = 0; i < Title.Count; i++)
            //{
            //    SEO seo = new();

            //    CountDownLanguage countDownLanguage = new()
            //    {
            //        ID = LangID[i],
            //        Title = Title[i],
                    
            //        SEO = seo.SeoURL(Title[i]),
            //        LangCode = LangCode[i],
            //        CountDownID = CountDownID
            //    };
            //    var updatedEntity = _context.Entry(countDownLanguage);
            //    updatedEntity.State = EntityState.Modified;

            //}
            //_context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
