using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Translation_And_Food.Entity.TranslationEntity;

namespace Translation_And_Food.Interfaces
{
    internal interface ITranslationFactory
    {
        ITranslation FindTranslator(string language)
        {
            return new Translator();
        }
    }
}
