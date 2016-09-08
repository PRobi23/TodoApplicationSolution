using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TodoApplication.Model.Database
{
    /// <summary>
    /// The interface for the repository. With this it's easy to modify
    /// </summary>
    public interface IRepository
    {    
        void Insert(Todo todo);
        void Delete(Todo todo);
        void Update(Todo todo);
        Todo GetById(int id);
        ObservableCollection<Todo> FetchAll();

        int GetItemCount();

        void ClearTable();

        void CreateTable();
    }
}