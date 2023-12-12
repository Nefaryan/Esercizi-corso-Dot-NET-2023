using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
            throw new NotImplementedException();
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, T item)
        {
            throw new NotImplementedException();
        }
    }
}
