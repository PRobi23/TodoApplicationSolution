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

        public ObservableCollection<Todo> TodoCollection { get; private set; }

        private Todo todo;
        public MainViewModel()
        {
            AddTodoItemCommand = new RelayCommand<string>(AddTodo);
            todo = new Todo();
        }     


        public async Task InitAsync()
        {
            if (TodoCollection != null)
            {
                // Prevent memory leak in Android
                var peopleCopy = TodoCollection.ToList();
                TodoCollection = new ObservableCollection<Todo>(peopleCopy);
                return;
            }

            TodoCollection = new ObservableCollection<Todo>();

            var todo = InitTodoList();

            TodoCollection.Clear();
            foreach (var person in todo)
            {
                TodoCollection.Add(person);
            }

        }

        private IEnumerable<Todo> InitTodoList()
        {
            var todo = SqLiteRepository.SqLiteRepo.FetchAll();
            return todo;
        }

        private void AddTodo(string todoName)
        {
            todo.Name = todoName;
            var createTime = TimeZone.CurrentTimeZone.ToUniversalTime(DateTime.UtcNow);
            todo.CreateTime = createTime;

           // TodoCollection.Add(todo);
            RaisePropertyChanged("Name");
        }
    }
}