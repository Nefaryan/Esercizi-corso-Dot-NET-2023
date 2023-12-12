using Data.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Data.Context
{
    internal class DataContex<T> : IDataContext<T> where T : class
    {
        readonly string _filePath;

        public DataContex(string filePath)
        {
            _filePath = filePath;

            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, "[]");
            }
        }

        public void AddItem(T item)
        {
            List<T> items = GetAll();
            items.Add(item);
            SavaData(items);
        }

        public string Delete(int id)
        {
            List<T> items = GetAll();
            T itemToDelete = items.FirstOrDefault(i=>GetId(i) == id);
            if(itemToDelete != null)
            {
                items.Remove(itemToDelete);
                SavaData(items);
                return "Elemento eliminato";
            }
            else
            {
                return "Elemento non trovato";
            }
        }

        public List<T> GetAll()
        {
            string data = File.ReadAllText(_filePath);
            List<T> list =JsonConvert.DeserializeObject<List<T>>(data);
            return list ?? new List<T>();
        }

        public T GetById(int id)
        {
            List<T> items = GetAll();
            return items.FirstOrDefault(i=>GetId(i) == id);
        }

        public void Update(int id, T item)
        {
            List<T> items = GetAll();
            T itemToUpdate = items.FirstOrDefault(i =>GetId(i) == id);
            if(itemToUpdate != null)
            {
                items.Remove(itemToUpdate);
                items.Add(item);
                SavaData(items);
            }
        }

        private void SavaData(List<T> item) 
        { 
            string data = JsonConvert.SerializeObject(item, Formatting.Indented);
            File.WriteAllText(_filePath, data);
        }

        private int GetId(T item)
        {
            var idProperty = typeof(T).GetProperty("Id");
            return (int)idProperty.GetValue(item);
        }

    }
}
