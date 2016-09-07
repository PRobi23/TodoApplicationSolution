using Android.App;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using TodoApplication.Model;
using TodoApplication.Model.Database;

namespace TodoApplication.ViewModel
{
    public class MainViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public RelayCommand<string> AddTodoItemCommand { get; private set; }

        public ObservableCollection<Todo> TodoCollection
        {
            get;

            private set;
            
        }
        private Todo todo;

        public MainViewModel()
        {
            AddTodoItemCommand = new RelayCommand<string>(AddTodo);
           
        }


        public async Task InitAsync()
        {
            if (TodoCollection != null)
            {
                // Prevent memory leak in Android
                var todoCopy = TodoCollection.ToList();
                TodoCollection = new ObservableCollection<Todo>(todoCopy);
                return;
            }

            TodoCollection = new ObservableCollection<Todo>();

            var todoes = InitTodoList();

            TodoCollection.Clear();
            foreach (var todo in todoes)
            {
                TodoCollection.Add(todo);
            }

        }

        private IEnumerable<Todo> InitTodoList()
        {
            var todo = SqLiteRepository.SqLiteRepo.FetchAll();
            return todo;
        }

        private void AddTodo(string todoName)
        {
            //SqLiteRepository.SqLiteRepo.ClearTable();
            todo = new Todo();
            todo.Name = todoName;
            var createTime = DateTime.UtcNow;
            todo.CreateTime = createTime;

            if (todo.TodoId == 0 && TodoCollection.Count > 0)
            {
                int id = TodoCollection.Max(x => x.TodoId);
                todo.TodoId = id + 1;
            }
            //TodoCollection = SqLiteRepository.SqLiteRepo.FetchAll();
            TodoCollection.Add(todo);           
        }
    }
}