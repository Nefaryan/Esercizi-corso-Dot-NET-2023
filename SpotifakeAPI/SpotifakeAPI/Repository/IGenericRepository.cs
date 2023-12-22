using System.Collections.Generic;

namespace SpotifakeAPI.Repository.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        public void SaveData(T t);
        public T GetById(int id);
        public List<T> GetAll();
        public string Delete(int id);
        public void Update(int  id, T t);
    }
}
