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
            PostgreConnection.Connection().Execute(CreateQuery, author);
        }

        public void Delete(int id)
        {
            PostgreConnection.Connection().Execute(DeleteQuery, id);
        }

        public Author Get(int id)
        {
            return PostgreConnection.Connection().Query<Author>(GetQuery).FirstOrDefault();
        }

        public List<Author> GetAll()
        {
            return PostgreConnection.Connection().Query<Author>(GetAllQuery).ToList();
        }

        public void Update(Author author)
        {
            PostgreConnection.Connection().Execute(UpdateQuery, author);
        }
    }
}
