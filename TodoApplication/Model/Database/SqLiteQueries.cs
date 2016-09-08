using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApplication.Model.Database
{
    /// <summary>
    /// Class for the sqlite queries. 
    /// </summary>
    public class SqLiteQueries
    {

        public SqLiteQueries()
        {
        }
        /// <summary>
        /// Inserts the data.
        /// </summary>
        /// <param name="todoItem">The todo item.</param>
        public void InsertData(Todo todoItem)
        {
            TodoItemRepository.Instance.Connection.Insert(todoItem);
        }

        /// <summary>
        /// Gets all todo item.
        /// </summary>
        /// <returns></returns>
        public List<Todo> GetAllTodoItem()
        {
            return TodoItemRepository.Instance.Connection.Table<Todo>().ToList();
        }

        /// <summary>
        /// Creates the table.
        /// </summary>
        public void CreateTable()
        {
            TodoItemRepository.Instance.Connection.CreateTable<Todo>();
        }


        /// <summary>
        /// Gets the item count.
        /// </summary>
        /// <returns></returns>
        public int GetItemCount()
        {
            return TodoItemRepository.Instance.Connection.Table<Todo>().Count();
        }

        /// <summary>
        /// Returns the by identifier.
        /// </summary>
        /// <param name="todoId">The todo identifier.</param>
        /// <returns></returns>
        public Todo ReturnById(int todoId)
        {
            return TodoItemRepository.Instance.Connection.Get<Todo>(todoId);
        }

        /// <summary>
        /// Clears the table.
        /// </summary>
        public void ClearTable()
        {
            TodoItemRepository.Instance.Connection.DeleteAll<Todo>();
        }
    }
}