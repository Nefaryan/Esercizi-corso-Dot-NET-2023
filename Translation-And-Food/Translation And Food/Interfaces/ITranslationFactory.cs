using System.Collections.Generic;
using Translation_And_Food.Entity.TranslationEntity;

namespace Translation_And_Food.Interfaces
{
    internal interface ITranslationFactory
    {
        public Translator FindTranslator(string language, List<Translator> trans);
    }
}

