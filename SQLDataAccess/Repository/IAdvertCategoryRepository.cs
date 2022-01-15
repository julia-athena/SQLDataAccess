using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDataAccess.Repository
{
    public interface IAdvertCategoryRepository
    {
        void Create(AdvertCategory category);
        void Delete(int id);
        AdvertCategory Get(int id);
        List<AdvertCategory> GetByAdvertId(int advertId);
        List<AdvertCategory> GetAll();
    }
}
