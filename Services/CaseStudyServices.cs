using DataAccess;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CaseStudyServices
    {
        private readonly OleevDbContext _context;

        public CaseStudyServices(OleevDbContext context)
        {
            _context = context;
        }

        public List<CaseStudyLanguage> GetAll()
        {
            var caseStudy = _context.CaseStudyLanguages.Include(x => x.CaseStudy).Where(x => x.LangCode == "AZ").ToList();

            return caseStudy;
        }

        public void CreateCaseStudy(string Title,string LangCode,string SEO, string PhotoURL)
        {
            CaseStudy caseStudy = new()
            {
                PhotoURL = PhotoURL,
                CreatedDate = DateTime.Now
            };

            _context.CaseStudies.Add(caseStudy);
            _context.SaveChanges();

            CaseStudyLanguage caseStudyLanguage = new()
            {
                Title = Title,
                LangCode = LangCode,
                SEO = SEO,
                CaseStudyID = caseStudy.ID
            };
            _context.CaseStudyLanguages.Add(caseStudyLanguage);

            _context.SaveChanges();


        }



    }
}
