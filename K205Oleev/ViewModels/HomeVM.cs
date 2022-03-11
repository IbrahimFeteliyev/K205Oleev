using Entities;

namespace K205Oleev.ViewModels
{
    public class HomeVM
    {
        public List<AboutLanguage> AboutLanguages { get; set; }
        public About About { get; set; }
        public List<InfoLanguage> InfoLanguages { get; set; }
        public InfoLanguage InfoLanguage { get; set; }
        public Info Info { get; set; }
        public List<OurServiceLanguage> OurServiceLanguages { get; set; }
        public OurService OurService { get; set; }
    }
}
