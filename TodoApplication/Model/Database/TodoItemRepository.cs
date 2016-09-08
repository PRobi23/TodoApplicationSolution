
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace TodoApplication.Model.Database
{
    public class TodoItemRepository : IRepository
    {


        private readonly string dbPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.Personal), "database.db3");

        public SQLiteConnection Connection { get; set; }

        private static readonly Lazy<TodoItemRepository> instance
           = new Lazy<TodoItemRepository>(() => new TodoItemRepository());

        /// <summary>
        /// Gets the database.
        /// </summary>
        /// <value>
        /// The database.
        /// </value>
        public static TodoItemRepository Instance
        {
            get { return instance.Value; }
        }


        /// <summary>
        /// The sqlite queries
        /// </summary>
        private SqLiteQueries sqliteQueries = new SqLiteQueries();
        /// <summary>
        /// Initializes a new instance of the <see cref="TodoItemRepository"/> class.
        /// </summary>
        public TodoItemRepository(SQLiteConnection connection)
        {        
            Connection = connection;
        }

        public TodoItemRepository()
        {
            Connection = new SQLiteConnection(new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid(), dbPath);
        }

        /// <summary>
        /// Deletes the specified todo item. Now it was not needed
        /// </summary>
        /// <param name="todoItem">The todo item.</param>
        /// <exception cref="NotImplementedException"></exception>
        public void Delete(Todo todoItem)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Fetches all.
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Todo> FetchAll()
        {
            return new ObservableCollection<Todo>(sqliteQueries.GetAllTodoItem());
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Todo GetById(int id)
        {
            return sqliteQueries.ReturnById(id);
        }

        /// <summary>
        /// Inserts the specified todo item.
        /// </summary>
        /// <param name="todoItem">The todo item.</param>
        public void Insert(Todo todoItem)
        {
            sqliteQueries.InsertData(todoItem);
        }

        /// <summary>
        /// Updates the specified todo item.
        /// </summary>
        /// <param name="todoItem">The todo item.</param>
        public void Update(Todo todoItem)
        {

        }

        /// <summary>
        /// Gets the item count.
        /// </summary>
        /// <returns></returns>
        public int GetItemCount()
        {
            return sqliteQueries.GetItemCount();
        }

        /// <summary>
        /// Creates the table.
        /// </summary>
        public void CreateTable()
        {
            sqliteQueries.CreateTable();
        }

        /// <summary>
        /// Clears the table.
        /// </summary>
        public void ClearTable()
        {
            sqliteQueries.ClearTable();
        }
    }
}