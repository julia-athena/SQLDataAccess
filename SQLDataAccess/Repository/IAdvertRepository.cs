using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDataAccess.Repository
{
    public interface IAdvertRepository: IGenericRepository<Advert, int> 
    {
       List<Advert> GetByParams(int? authorId, int? categoryId, string substringInTitle);
    }
}
