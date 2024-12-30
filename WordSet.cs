namespace DictionaryVersion2.Models
{
    public class WordSet
    {
        public string[] Kyrgyz { get; set; }
        public string[] English { get; set; }
        public string[] German { get; set; }
        public string[] Chinese { get; set; }
        public string FilePath { get; set; }
        public Dictionary<string, int> LangIdx { get; set; }

        public WordSet()
        {
            LangIdx = new Dictionary<string, int>();
        }
    }
}
