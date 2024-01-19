using Translation_And_Food.Interfaces;

namespace Translation_And_Food.Entity.TranslationEntity
{
    internal class Translator : ITranslation
    {
        public string Name { get; set; }
        public string Language { get; set; }
    }
}

