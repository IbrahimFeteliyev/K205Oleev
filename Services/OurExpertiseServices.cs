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
    public class OurExpertiseServices
    {
        private readonly OleevDbContext _context;

        public OurExpertiseServices(OleevDbContext context)
        {
            _context = context;
        }

        public List<OurExpertiseLanguage> GetAll()
        {
            var ourexpertise = _context.OurExpertiseLanguages.Include(x => x.OurExpertise).Where(x => x.LangCode == "AZ").ToList();

            return ourexpertise;
        }

        public void CreateOurExpertise(string Title, string Description, string SubTitle, string SubDescription, string LangCode, string SEO, string PhotoURL, string Icon)
        {
            OurExpertise ourExpertise = new()
            {
                PhotoURL = PhotoURL,
                Icon = Icon,
                CreatedDate = DateTime.Now,
            };
            _context.OurExpertises.Add(ourExpertise);
            _context.SaveChanges();

            OurExpertiseLanguage OurExpertiseLanguage = new()
            {
                Title = Title,
                Description = Description,
                SubTitle = SubTitle,
                SubDescription = SubDescription,
                LangCode = LangCode,
                SEO = SEO,
                OurExpertiseID = ourExpertise.ID,
            };
            _context.OurExpertiseLanguages.Add(OurExpertiseLanguage);

            _context.SaveChanges();

        }
    }
}
