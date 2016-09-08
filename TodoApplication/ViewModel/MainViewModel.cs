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
    /// <summary>
    /// The main view model class
    /// </summary>
    /// <seealso cref="GalaSoft.MvvmLight.ViewModelBase" />
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    public class MainViewModel : ViewModelBase, INotifyPropertyChanged
    {
        /// <summary>
        /// Gets the add todo item command.
        /// </summary>
        /// <value>
        /// The add todo item command.
        /// </value>
        public RelayCommand<string> AddTodoItemCommand { get; private set; }

        /// <summary>
        /// Gets the todo collection.
        /// </summary>
        /// <value>
        /// The todo collection.
        /// </value>
        public ObservableCollection<Todo> TodoCollection
        {
            get;

            private set;            
        }
        /// <summary>
        /// The todo
        /// </summary>
        private Todo todo;

        /// <summary>
        /// The todo item repository
        /// </summary>
        private IRepository todoItemRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// </summary>
        public MainViewModel()
        {
            AddTodoItemCommand = new RelayCommand<string>(AddTodo);
            todoItemRepository = TodoItemRepository.Instance;
        }


        /// <summary>
        /// Initializes the asynchronous.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Initializes the todo list. If here the repo change, than we just have to initalize another one.
        /// </summary>
        /// <returns></returns>
        private IEnumerable<Todo> InitTodoList()
        {
            var todo = todoItemRepository.FetchAll();
            return todo;
        }

        /// <summary>
        /// Adds the todo.
        /// </summary>
        /// <param name="todoName">Name of the todo.</param>
        private void AddTodo(string todoName)
        {
            todo = new Todo();
            todo.Name = todoName;
            var createTime = DateTime.UtcNow;
            todo.CreateTime = createTime;

            if (todo.TodoId == 0 && TodoCollection.Count > 0)
            {
                int id = TodoCollection.Max(x => x.TodoId);
                todo.TodoId = id + 1;
            }
            TodoCollection.Add(todo);

            RaisePropertyChanged("SetTextViewToDefault");
        }
    }
}