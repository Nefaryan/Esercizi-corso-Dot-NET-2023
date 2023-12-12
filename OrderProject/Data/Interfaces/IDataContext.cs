using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    internal interface IDataContext<T>
    {
        List<T> GetAll();
        void AddItem(T item);
        T GetById(int id);
        void Update(int id,T item);
        string Delete(int id);

    }
}
