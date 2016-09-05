using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApplication.Model.Database
{
    public class SqLiteQueries
    {

        public void InsertData(Todo todoItem)
        {
            SqLiteDatabase.Database.Insert(todoItem);
        }

        public List<Todo> GetAllTodoItem()
        {
            return SqLiteDatabase.Database.Table<Todo>().ToList();
        }

        public void CreateTable()
        {
            SqLiteDatabase.Database.CreateTable<Todo>();
        }


        public int GetItemCount()
        {
            return SqLiteDatabase.Database.Table<Todo>().Count();
        }

        public Todo ReturnById(int todoId)
        {
            return SqLiteDatabase.Database.Get<Todo>(todoId);
        }

        public void ClearTable()
        {
            SqLiteDatabase.Database.DeleteAll<Todo>();
        }
    }
}