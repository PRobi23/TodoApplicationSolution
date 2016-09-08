using Microsoft.VisualStudio.TestTools.UnitTesting;
using TodoApplication.Model.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using System.IO;
using SQLite.Net;

namespace TodoApplication.Model.Database.Tests
{
    [TestClass()]
    public class TodoItemRepositoryTests
    {
        [TestMethod()]
        public void InsertTest()
        {
            SQLiteConnection conn = TestPath.GetTestSqliteConnection();

            TodoItemRepository todoItemRepository = new TodoItemRepository(conn);

            Todo expected = new Todo { Name = "Teszt", CreateTime = new DateTime(2015, 05, 05) };
            todoItemRepository.CreateTable();
            todoItemRepository.Insert(expected);           

            Todo result = todoItemRepository.GetById(expected.TodoId);

            Assert.AreEqual(expected, result);
        }
    }

    public class TestPath
    {
        public static string GetTempFileName()
        {
            return Path.GetTempFileName();
        }

        public static SQLiteConnection GetTestSqliteConnection()
        {
            return new SQLiteConnection(new SQLite.Net.Platform.Win32.SQLitePlatformWin32(),Path.Combine(GetTempFileName(),"test.db"));
        }

    }
}