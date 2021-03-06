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
    public class CountDownServices
    {
        private readonly OleevDbContext _context;

        public CountDownServices(OleevDbContext context)
        {
            _context = context;
        }

        public List<CountDownLanguage> GetAll()
        {

            var countdown = _context.CountDownLanguages.Include(x => x.CountDown).Where(x => x.LangCode == "AZ").ToList();

            return countdown;
        }

        public void CreateCountDown(string Title, string LangCode, string SEO, int Count)
        {
            CountDown countDown = new()
            {
                Count = Count,
                CreatedDate = DateTime.Now
            };

            _context.CountDowns.Add(countDown);
            _context.SaveChanges();


            CountDownLanguage countDownLanguage = new()
            {
                Title = Title,
                LangCode = LangCode,
                SEO = SEO,
                CountDownID = countDown.ID
            };
            _context.CountDownLanguages.Add(countDownLanguage);

            _context.SaveChanges();

        }


    }
}
