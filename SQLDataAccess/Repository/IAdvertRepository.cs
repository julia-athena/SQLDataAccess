using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDataAccess.Repository
{
    public interface IAdvertRepository
    {
        void Create(Advert advert);
        void Update(Advert advert);
        void Delete(int id);
        Advert Get(int id);
        List<Advert> GetAll();
    }
}
