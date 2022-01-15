using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;


namespace SQLDataAccess.Repository.Dapper
{
    public class DapperAdvertRepository : IAdvertRepository
    {
        private static readonly string CreateQuery = "insert into Adverts (Id, Title) VALUES(@Id, @Title)";
        private static readonly string DeleteQuery = "delete from Adverts where Id = @id";
        private static readonly string UpdateQuery = "update Adverts SET Title = @Title WHERE Id = @Id";
        private static readonly string GetQuery = "select * from Adverts WHERE Id = @id";
        private static readonly string GetAllQuery = "select * from Adverts";

        public void Create(Advert advert)
        {
            PostgreConnection.Connection().Execute(CreateQuery, advert);
        }

        public void Delete(int id)
        {
            PostgreConnection.Connection().Execute(DeleteQuery, id);
        }

        public Advert Get(int id)
        {
            return PostgreConnection.Connection().Query<Advert>(GetQuery).FirstOrDefault();
        }

        public List<Advert> GetAll()
        {
            return PostgreConnection.Connection().Query<Advert>(GetAllQuery).ToList();
        }

        public void Update(Advert advert)
        {
            PostgreConnection.Connection().Execute(UpdateQuery, advert);
        }
    }
}
