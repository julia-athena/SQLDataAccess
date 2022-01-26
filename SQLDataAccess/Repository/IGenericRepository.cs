using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDataAccess.Repository
{
    public interface IGenericRepository<T,ID>
    {
        void Create(T t);
        void Update(T t);
        void Delete(ID id);
        T Get(ID id);
        List<T> GetAll();
    }
}
