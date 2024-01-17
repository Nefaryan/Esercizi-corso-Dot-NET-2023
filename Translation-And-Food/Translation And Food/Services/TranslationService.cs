using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Translation_And_Food.Entity.TranslationEntity;
using Translation_And_Food.Factory.Translation;
using Translation_And_Food.Interfaces;

namespace Translation_And_Food.Services
{
    internal class TranslationService
    {
        private readonly TranslationFactory _translatorFactory;
        private readonly List<Translator> _translators;

        public TranslationService(TranslationFactory translatorFactory, List<Translator> translators)
        {
            _translatorFactory = translatorFactory ?? throw new ArgumentNullException(nameof(translatorFactory));
            _translators = translators ?? throw new ArgumentNullException(nameof(translators));
        }

        public async Task<Translator> FindTransaltor(string language)
        {
            try
            {
                var translator = _translators.FirstOrDefault(t => t.Language ==language);
                if (translator != null)
                {
                    await Task.Delay(100);
                    return translator;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }

}
