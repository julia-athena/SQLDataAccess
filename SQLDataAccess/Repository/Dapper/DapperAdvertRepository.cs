using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;


namespace SQLDataAccess.Repository.Dapper
{
    public class DapperAdvertRepository : IAdvertRepository
    {
        private static readonly string CreateQuery = "insert into adverts (id, title, author_id) VALUES(@Id, @Title, @AuthorId)";
        private static readonly string DeleteQuery = "delete from adverts where id = @Id";
        private static readonly string UpdateQuery = "update adverts SET title = @Title, author_id = @AuthorId WHERE id = @Id";
        private static readonly string GetQuery = "select id, title, author_id as AuthorId from adverts WHERE id = @Id";
        private static readonly string GetAllQuery = "select id, title, author_id as AuthorId from adverts";
        private static readonly string GetByParamsQuery = "select distinct a.id, a.title, a.author_id as AuthorId " +
                                                          "from adverts a join adverts_categories cat on cat.advert_id = a.id " +
                                                          "where (a.author_Id = @AuthorId or @AuthorId is null) " +
                                                            "and (cat.category_id = @CategoryId or @CategoryId is null) " +
                                                            "and (a.title ~ ('.*' || @StrInTitle || '.*') or @StrInTitle is null or @StrInTitle = '')";

        public void Create(Advert advert)
        {
            using (var connection = PostgreConnection.Connection())
            {
                connection.Execute(CreateQuery, advert);
            }
        }

        public void Delete(int id)
        {
            using (var connection = PostgreConnection.Connection())
            {
                PostgreConnection.Connection().Execute(DeleteQuery, new { Id = id });
            }
        }

        public Advert Get(int id)
        {
            using (var connection = PostgreConnection.Connection())
            {
                return connection.Query<Advert>(GetQuery, new { Id = id }).FirstOrDefault();
            }
        }

        public List<Advert> GetAll()
        {
            using (var connection = PostgreConnection.Connection())
            {
                return connection.Query<Advert>(GetAllQuery).ToList();
            }
        }


        public void Update(Advert advert)
        {
            using (var connection = PostgreConnection.Connection())
            {
                connection.Execute(UpdateQuery, advert);
            }
        }

        public List<Advert> GetByParams(int? authorId, int? categoryId, string substringInTitle)
        {
            using (var connection = PostgreConnection.Connection())
            {
                return connection.Query<Advert>(GetByParamsQuery, new {AuthorId = authorId, CategoryId = categoryId, StrInTitle = substringInTitle}).ToList();
            }
        }
    }
}
