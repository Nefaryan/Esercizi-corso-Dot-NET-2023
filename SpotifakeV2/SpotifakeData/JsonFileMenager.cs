using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SpotifakeData
{
    public class JsonFileMenager
    {
        public static List<T> LeggiDaJson<T>(string percorso)
        {
            try
            {
                string jsonData = File.ReadAllText(percorso);
                return JsonConvert.DeserializeObject<List<T>>(jsonData);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore durante la lettura da JSON: {ex.Message}");
                return null;
            }
        }

        public static void ScriviSuJson<T>(List<T> dati, string percorso)
        {
            try
            {
                string jsonData = JsonConvert.SerializeObject(dati, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(percorso, jsonData);
                Console.WriteLine("Dati scritti con successo su JSON.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore durante la scrittura su JSON: {ex.Message}");
            }
        }
    }
}

