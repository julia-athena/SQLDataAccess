using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;


namespace SQLDataAccess.Repository.Dapper
{
    public class DapperAdvertRepository : IAdvertRepository
    {
        private static readonly string CreateQuery = "insert into adverts (id, title, author_id) VALUES(@Id, @Title, @AuthorId)";
        private static readonly string DeleteQuery = "delete from adverts where id = @id";
        private static readonly string UpdateQuery = "update adverts SET title = @Title, author_id = @AuthorId WHERE id = @Id";
        private static readonly string GetQuery = "select id, title, author_id as AuthorId from adverts WHERE id = @id";
        private static readonly string GetAllQuery = "select id, title, author_id as AuthorId from adverts";

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
