using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifakeData.DataContext
{
    public class DBContext
    {
        private string _folderPath;

        public DBContext(string folderPath)
        {
            SetFolderPath(folderPath);
        }

        public void SetFolderPath(string folderPath)
        {
            _folderPath = folderPath;
            Directory.CreateDirectory(_folderPath);
        }

        public List<T> GetAll<T>() where T : class
        {
            var items = new List<T>();

            foreach(var file in Directory.GetFiles(_folderPath, $"{typeof(T).Name}.json"))
            {
                var jsonData = File.ReadAllText(file);
                var item = JsonConvert.DeserializeObject<T>(jsonData);

                items.Add(item);                
            }
            return items;
        }
        public T GetByName<T>(string title) where T : class
        {
            var filepath = Path.Combine(_folderPath, $"{typeof(T).Name}{title}.json");
            if (File.Exists(filepath))
            {
                var jsonData = File.ReadAllText(_folderPath);
                return JsonConvert.DeserializeObject<T>(jsonData);
            }
            return null;
        }

        public T GetById<T>(int id) where T : class
        {
            var filePath = Path.Combine(_folderPath, $"{typeof(T).Name}{id}.json");

            if(File.Exists(filePath))
            {
                var jsonData = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<T>(jsonData);
            }
            return null;
        }

        public void Add<T>(T item) where T : class 
        {
            var itemId = typeof(T).GetProperty("Id").GetValue(item);
            var filePath = Path.Combine(_folderPath, $"{typeof(T).Name}{itemId}.json");

            if(!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }
            var jsonData = JsonConvert.SerializeObject(item, Formatting.Indented);
            File.WriteAllText(filePath, jsonData);
        }
    }
}
