﻿using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;


namespace SQLDataAccess.Repository.Dapper
{
    public class DapperCategoryRepository : ICategoryRepository
    {
        private static readonly string CreateQuery = "insert into category_titles (id, title) VALUES(@Id, @Title)";
        private static readonly string DeleteQuery = "delete from category_titles where id = @id";
        private static readonly string GetQuery = "select * from category_titles WHERE id = @id";
        private static readonly string GetAllQuery = "select * from category_titles";

        public void Create(Category category)
        {
            PostgreConnection.Connection().Execute(CreateQuery, category);
        }

        public void Delete(int id)
        {
            PostgreConnection.Connection().Execute(DeleteQuery, id);
        }

        public Category Get(int id)
        {
            return PostgreConnection.Connection().Query<Category>(GetQuery).FirstOrDefault();
        }

        public List<Category> GetAll()
        {
            return PostgreConnection.Connection().Query<Category>(GetAllQuery).ToList();
        }

        public List<Category> GetByAdvertId(int advertId)
        {
            throw new NotImplementedException();
        }
    }
}