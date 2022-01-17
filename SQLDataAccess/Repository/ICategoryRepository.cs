using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDataAccess.Repository
{
    public interface ICategoryRepository
    {
        void Create(Category category);
        void Delete(int id);
        Category Get(int id);
        List<Category> GetByAdvertId(int advertId);
        List<Category> GetAll();
    }
}
