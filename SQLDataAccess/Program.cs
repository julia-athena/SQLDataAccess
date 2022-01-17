using SQLDataAccess.Repository.Dapper;
using System;
using System.Collections.Generic;


namespace SQLDataAccess
{
    class Program
    {
        static void Main(string[] args)
        {
            GetCategories();
            GetAuthors();
            GetAdverts();      
        }

        static void GetCategories()
        {
            Console.WriteLine("Категории");
            var repo = new DapperCategoryRepository();
            var res = repo.GetAll();
            foreach(var item in res)
            {
                Console.WriteLine("{0,3} | {1,20}", item.Id, item.Title);
            }
            Console.WriteLine();

        }
        static void GetAuthors()
        {
            Console.WriteLine("Авторы объявлений");
            var repo = new DapperAuthorRepository();
            var res = repo.GetAll();
            foreach (var item in res)
            {
                Console.WriteLine("{0,3} | {1,15} | {2,15} | {3,30}", item.Id, item.FirstName, item.FamilyName, item.Email);
            }
            Console.WriteLine();
        }

        static void GetAdverts()
        {
            Console.WriteLine("ОбЪявления");
            var repo = new DapperAdvertRepository();
            var res = repo.GetAll();
            foreach (var item in res)
            {
                Console.WriteLine("{0,3} | {1,40} | {2,3}", item.Id, item.Title, item.AuthorId);
            }
            Console.WriteLine();
        }
    }
}
