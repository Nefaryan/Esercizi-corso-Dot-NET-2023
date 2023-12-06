using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifakeService.Interfaces
{
    internal interface IService<T> where T : class
    {
        public void AddItem(T item);
        public List<T> GetAllItem();
        public T GetItem(int id);

    }
}
