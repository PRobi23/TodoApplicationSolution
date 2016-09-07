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

            SetContentView(Resource.Layout.MainView);
           // SqLiteRepository.SqLiteRepo.CreateTable();

            await ViewModel.InitAsync();
            
            todoAdapter = new TodoAdapter(this, ViewModel.TodoCollection);

            textBinding = this.SetBinding(() => todoItemNameFromUser.Text, BindingMode.TwoWay);

            addTodoButton.SetCommand("Click", ViewModel.AddTodoItemCommand, textBinding);

            todoListView.Adapter = todoAdapter;

            //todoListView.AddH    eader  
        }

        protected override void OnResume()
        {
            base.OnResume();
        }
        protected override void OnPause()
        {
            base.OnPause();

            if (IsFinishing)
            {
                SqLiteRepository.SqLiteRepo.ClearTable();
            }
        }
    }
}

