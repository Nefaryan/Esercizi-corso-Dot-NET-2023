using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
