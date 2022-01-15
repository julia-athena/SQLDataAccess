using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDataAccess.Repository.Dapper
{
    public class DapperAuthorRepository : IAuthorRepository
    {
        private static readonly string CreateQuery = "insert into Authors (Id, FirstName, FamilyName, Email) VALUES(@AuthorId, @FirstName, @FamilyName, @Email)";
        private static readonly string DeleteQuery = "delete from Authors where Id = @id";
        private static readonly string UpdateQuery = "update Authors SET FirstName = @FirstName, FamilyName = @FamilyName, Email = Email WHERE Id = @Id";
        private static readonly string GetQuery = "select * from Authors WHERE Id = @id";
        private static readonly string GetAllQuery = "select * from Authors";

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
