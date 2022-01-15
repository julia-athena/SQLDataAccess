using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;


namespace SQLDataAccess.Repository.Dapper
{
    public class DapperAdvertCategoryRepository : IAdvertCategoryRepository
    {
        private static readonly string CreateQuery = "insert into AdvertCategories (Id, Name) VALUES(@Id, @Name)";
        private static readonly string DeleteQuery = "delete from AdvertCategories where Id = @id";
        private static readonly string GetQuery = "select * from AdvertCategories WHERE Id = @id";
        private static readonly string GetAllQuery = "select * from AdvertCategories";

        public void Create(AdvertCategory category)
        {
            PostgreConnection.Connection().Execute(CreateQuery, category);
        }

        public void Delete(int id)
        {
            PostgreConnection.Connection().Execute(DeleteQuery, id);
        }

        public AdvertCategory Get(int id)
        {
            return PostgreConnection.Connection().Query<AdvertCategory>(GetQuery).FirstOrDefault();
        }

        public List<AdvertCategory> GetAll()
        {
            return PostgreConnection.Connection().Query<AdvertCategory>(GetAllQuery).ToList();
        }

        public List<AdvertCategory> GetByAdvertId(int advertId)
        {
            throw new NotImplementedException();
        }
    }
}
