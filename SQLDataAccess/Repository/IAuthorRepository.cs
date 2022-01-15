using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDataAccess.Repository
{
    public interface IAuthorRepository
    {
        void Create(Author author);
        void Update(Author author);
        void Delete(int id);
        Author Get(int id);
        List<Author> GetAll();
    }
}
