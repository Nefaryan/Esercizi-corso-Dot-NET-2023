using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Translation_And_Food.Entity.TranslationEntity;

namespace Translation_And_Food.Services
{
    internal class TranslationService
    {
        private readonly List<Translator> translators;

        public TranslationService(List<Translator> translators)
        {
            this.translators = translators;
        }

        public async Task<Translator> FindTransaltor(string language)
        {
            try
            {
                
                var translator = translators.FirstOrDefault(t => t.Language == language);
                await Task.Delay(500);
                return translator;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
