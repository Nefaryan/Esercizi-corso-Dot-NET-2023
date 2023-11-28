using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SpotifakeDB.Repository
{
    public class CSVData<T> where T : class, new()
    {

        public static void WriteonFile(string path, List<T> data)
        {
            List<string> list = new List<string>();

            StringBuilder sb = new StringBuilder();

            var cols = data[0].GetType().GetProperties();

            if (File.Exists(path))
            {
                File.Delete(path);
            }
            foreach (var col in cols)
            {
                sb.Append(col.Name);
                sb.Append(',');
            }

            list.Add(sb.ToString().Substring(0, sb.Length - 1));

            foreach (var row in data)
            {

                sb = new StringBuilder();
                foreach (var col in cols)
                {
                    sb.Append(col.GetValue(row));
                    sb.Append(',');
                }

                list.Add(sb.ToString().Substring(0, sb.Length - 1));
            }
            File.AppendAllLines(path, list);
        }
        public static List<T> CreateObject(List<string> csv)
        {
            List<T> list = new List<T>();
            string[] headers = csv.ElementAt(0).Split(',');
            csv.RemoveAt(0);

            bool isDatset = true;
            T entry = new T();
            PropertyInfo[] prop = entry.GetType().GetProperties();

            if (isDatset)
            {

                for (int i = 0; i < prop.Length; i++)
                {
                    if (prop.ElementAt(i).Name == headers[i])
                    {
                        continue;
                    }
                    else
                    {
                        isDatset = false;
                    }
                }
            }
            if (isDatset)
            {

                csv.RemoveAt(0);
                foreach (var line in csv)
                {
                    entry = new T();

                    #region eXTRACION
                    int j = 0;
                    string[] columns = line.Split(',');

                    foreach (var col in columns)
                    {
                        try
                        {
                            entry.GetType().GetProperty(headers[j])
                              .SetValue(entry,
                                 Convert.ChangeType(col,
                                     entry.GetType().GetProperty(headers[j])
                                       .PropertyType)
                              );
                        }
                        catch
                        {
                            throw;
                        }
                        j++;
                    }
                    #endregion

                    list.Add(entry);
                }
            }
            else Console.WriteLine("Errore: Oggetto e File Csv hanno Dataset diversi!");

            return list;
        }
    }
}

