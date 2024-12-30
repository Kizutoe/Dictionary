namespace DictionaryVersion2.Models
{
    public class TranslationViewModel
    {
        public string Input { get; set; }
        public string FromLang { get; set; }
        public string ToLang { get; set; }
        public DictionaryType DictionaryType { get; set; }
        public string Result { get; set; }

        public List<string> Languages { get; set; } = new List<string> { "Kyrgyz", "English", "German", "Chinese" };
    }

}
