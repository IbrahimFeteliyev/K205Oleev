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
    public class OurTestimonialServices
    {
        private readonly OleevDbContext _context;

        public OurTestimonialServices(OleevDbContext context)
        {
            _context = context;
        }


        public List<OurTestimonialLanguage> GetAll()
        {
            var ourtestimonial = _context.OurTestimonialLanguages.Include(x => x.OurTestimonial).Where(x => x.LangCode == "AZ").ToList();

            return ourtestimonial;
        }

        public void CreateOurTestimonial(string Title, string Description, string Name, string Profession, string LangCode, string SEO, string PhotoURL)
        {
            OurTestimonial ourTestimonial = new()
            {
                PhotoURL = PhotoURL,
                CreatedDate = DateTime.Now,
            };

            _context.OurTestimonials.Add(ourTestimonial);
            _context.SaveChanges();
            OurTestimonialLanguage OurTestimonialLanguage = new()
            {
                Title = Title,
                Description = Description,
                Name = Name,
                Profession = Profession,
                LangCode = LangCode,
                SEO = SEO,
                OurTestimonialID = ourTestimonial.ID
            };
            _context.OurTestimonialLanguages.Add(OurTestimonialLanguage);

            _context.SaveChanges();

        }
    }
}
