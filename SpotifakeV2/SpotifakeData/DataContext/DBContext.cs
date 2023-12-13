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
        private string _baseFolderPath;

        public DBContext(string baseFolderPath)
        {
            SetBaseFolderPath(baseFolderPath);
        }

        public void SetBaseFolderPath(string baseFolderPath)
        {
            _baseFolderPath = baseFolderPath;
            Directory.CreateDirectory(_baseFolderPath);
        }

        private string GetEntityFilePath<T>(object identifier)
        {
            var typeName = typeof(T).Name;
            var fileName = $"{typeName}_{identifier}.json";
            return Path.Combine(_baseFolderPath, fileName);
        }

        public List<T> GetAll<T>() where T : class
        {
            var items = new List<T>();

            foreach (var file in Directory.GetFiles(_baseFolderPath, $"{typeof(T).Name}_*.json"))
            {
                var jsonData = File.ReadAllText(file);
                var item = JsonConvert.DeserializeObject<T>(jsonData);
                items.Add(item);
            }

            return items;
        }

        public T GetById<T>(int id) where T : class
        {
            var filePath = GetEntityFilePath<T>(id);

            if (File.Exists(filePath))
            {
                var jsonData = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<T>(jsonData);
            }

            return null;
        }

        public void Add<T>(T item) where T : class
        {
            var itemId = typeof(T).GetProperty("Id")?.GetValue(item);
            if (itemId == null)
            {
                throw new ArgumentException("Entity must have an 'Id' property.");
            }

            var filePath = GetEntityFilePath<T>(itemId);

            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }

            var jsonData = JsonConvert.SerializeObject(item, Formatting.Indented);
            File.WriteAllText(filePath, jsonData);
        }
    }
}
