
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace TodoApplication.Model.Database
{
    public class SqLiteRepository : IRepository
    {

        private SqLiteQueries sqliteQueries = new SqLiteQueries();
        public SqLiteRepository()
        {

        }

        private static readonly Lazy<SqLiteRepository> sqLiteRepo
            = new Lazy<SqLiteRepository>(() => new SqLiteRepository());

        /// <summary>
        /// Gets the database.
        /// </summary>
        /// <value>
        /// The database.
        /// </value>
        public static SqLiteRepository SqLiteRepo
        {
            get
            {

                return sqLiteRepo.Value;
            }
        }

        public void Delete(Todo todoItem)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<Todo> FetchAll()
        {
            return new ObservableCollection<Todo>(sqliteQueries.GetAllTodoItem());
        }

        public Todo GetById(int id)
        {
            return sqliteQueries.ReturnById(id);
        }

        public void Insert(Todo todoItem)
        {
            sqliteQueries.InsertData(todoItem);
        }

        public void Update(Todo todoItem)
        {

        }

        public int GetItemCount()
        {
            return sqliteQueries.GetItemCount();
        }

        public void CreateTable()
        {
            sqliteQueries.CreateTable();
        }

        public void ClearTable()
        {
            sqliteQueries.ClearTable();
        }
    }
}