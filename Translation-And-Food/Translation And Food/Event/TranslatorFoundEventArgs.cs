using System;
using Translation_And_Food.Entity.TranslationEntity;

namespace Translation_And_Food.Event
{
    internal class TranslatorFoundEventArgs : EventArgs
    {
        public Translator Translator { get; }

        public TranslatorFoundEventArgs(Translator translator)
        {
           Translator = translator;
        }
    }
}
