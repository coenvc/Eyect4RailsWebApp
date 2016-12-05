using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eyect4rails.IRepository
{
    public interface IRepository<T> where T :class
    {
        bool Insert(T entity);
        void Update(int id, T entity);
        bool Delete(int id);
        T GetById(int id);
        List<T> GetAll();
    }
}
