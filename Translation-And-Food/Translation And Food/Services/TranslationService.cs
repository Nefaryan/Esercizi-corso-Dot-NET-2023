using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Translation_And_Food.Entity.TranslationEntity;
using Translation_And_Food.Event;
using Translation_And_Food.Factory.Translation;


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
                    OnTranslatorFound(translator);
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

        public event EventHandler<TranslatorFoundEventArgs> TranslatorFound;

        protected virtual void OnTranslatorFound(Translator translator) 
        {
          TranslatorFound.Invoke(this, new TranslatorFoundEventArgs(translator));
        }
    }

}
