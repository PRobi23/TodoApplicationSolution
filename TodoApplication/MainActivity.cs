using Android.App;
using Android.OS;
using Android.Widget;
using GalaSoft.MvvmLight.Helpers;
using TodoApplication.Model;
using TodoApplication.Model.Database;
using TodoApplication.ViewModel;

namespace TodoApplication
{
    [Activity(Label = "TodoApplication", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private MainViewModel ViewModel => ViewModelLocator.Instance.MainViewModel;

        private EditText todoItemNameFromUser => FindViewById<EditText>(Resource.Id.todoItemNameFromUser);

        private Button addTodoButton => FindViewById<Button>(Resource.Id.addButton);
        private ListView todoListView => FindViewById<ListView>(Resource.Id.todoList);

        private Binding<string, string> textBinding;

        private TodoAdapter todoAdapter;


        protected async override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.MainView);

            await ViewModel.InitAsync();

            todoAdapter = new TodoAdapter(this, ViewModel.TodoCollection);            

            textBinding = this.SetBinding(() => todoItemNameFromUser.Text, BindingMode.TwoWay);

            addTodoButton.SetCommand("Click", ViewModel.AddTodoItemCommand, textBinding);

            todoListView.Adapter = todoAdapter;

            // todoAdapter.SetBinding(() => MainViewModel.TodoCollection);
            //ObservableAdapter<Todo> todoAdapters = new ObservableAdapter<Todo>();
            //todoAdapters.DataSource = SqLiteRepository.SqLiteRepo.FetchAll();
            //todoAdapters.GetTemplateDelegate = new System.Func<int, Todo, Android.Views.View, Android.Views.View>

            //todoListView.Adapter = todoAdapters;
            //IQueryable<Todo> todoItems = SqLiteRepository.SqLiteRepo.FetchAll();           
        }

        protected override void OnResume()
        {
            base.OnResume();

            todoAdapter.NotifyDataSetChanged();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

        }
    }
}

