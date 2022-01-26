using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;


namespace SQLDataAccess.Repository.Dapper
{
    public class DapperAuthorRepository : IAuthorRepository
    {
        private static readonly string CreateQuery = "insert into authors (id, first_name, family_name, email) VALUES(@Id, @FirstName, @FamilyName, @Email)";
        private static readonly string DeleteQuery = "delete from authors where id = @id";
        private static readonly string UpdateQuery = "update authors SET first_name = @FirstName, family_name = @FamilyName, email = @Email WHERE id = @Id";
        private static readonly string GetQuery = "select * from authors WHERE id = @id";
        private static readonly string GetAllQuery = "select id Id, first_name as FirstName, last_name as FamilyName, email as Email from authors";

        public void Create(Author author)
        {
            using (var connection = PostgreConnection.Connection())
            {
                connection.Execute(CreateQuery, author);
            }
        }

        public void Delete(int id)
        {
            using (var connection = PostgreConnection.Connection())
            {
                connection.Execute(DeleteQuery, id);
            }
        }

        public Author Get(int id)
        {
            using (var connection = PostgreConnection.Connection())
            {
                return connection.Query<Author>(GetQuery, id).FirstOrDefault();
            }
        }

        public List<Author> GetAll()
        {
            using (var connection = PostgreConnection.Connection())
            {
                return connection.Query<Author>(GetAllQuery).ToList();
            }
        }

        public void Update(Author author)
        {
            using (var connection = PostgreConnection.Connection())
            {
                connection.Execute(UpdateQuery, author);
            }
        }
    }
}
