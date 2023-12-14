using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifakeData.Repository.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        public List<T> GetALL();
        public void Add(T item);

        public T GetById(int id);
    }
}
