using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Translation_And_Food.Entity.TranslationEntity;
using Translation_And_Food.Interfaces;

namespace Translation_And_Food.Factory.Translation
{
    internal class TranslationFactory : ITranslationFactory
    {
        public Translator FindTranslator(string language, List<Translator> trans)
        {
            return trans.FirstOrDefault(t => t.Language == language);
        }
    }
    
}
