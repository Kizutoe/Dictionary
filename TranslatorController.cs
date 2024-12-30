using Microsoft.AspNetCore.Mvc;
using DictionaryVersion2.Models;
using DictionaryVersion2.Services;

namespace DictionaryVersion2.Controllers
{
    public class TranslatorController : Controller
    {
        private readonly TranslatorService _translatorService;

        public TranslatorController()
        {
            _translatorService = new TranslatorService();
        }

        public IActionResult Index()
        {
            var model = new TranslationViewModel
            {
                Languages = new List<string> { "Kyrgyz", "English", "German", "Chinese" }
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Translate(TranslationViewModel model)
        {
            /*if (ModelState.IsValid)*/
            {
                model.Result = _translatorService.Translate(model.DictionaryType, model.Input, model.FromLang, model.ToLang);
            }
            return View("Index", model);
        }

        [HttpGet]
        public JsonResult GetAutocompleteSuggestions(string term, string fromLang, DictionaryType dictionaryType)
        {
            if (term == null)
            { 
                return Json(null); 
            }
            var wordSet = _translatorService.GetWordSet(dictionaryType);
            string[] from = _translatorService.GetLanguageArray(wordSet, fromLang);

            var suggestions = from.Where(w => w.StartsWith(term, StringComparison.OrdinalIgnoreCase))
                                  .Take(15) // Limit the number of suggestions
                                  .ToList();

            return Json(suggestions);
        }
    }
}
