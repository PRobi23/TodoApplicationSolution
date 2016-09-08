using Android.App;
using Android.OS;
using Android.Widget;
using GalaSoft.MvvmLight.Helpers;
using TodoApplication.Model;
using TodoApplication.Model.Database;
using TodoApplication.ViewModel;

namespace TodoApplication
{
    /// <summary>
    /// The main activity
    /// </summary>
    /// <seealso cref="Android.App.Activity" />
    [Activity(Label = "TodoApplication", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private MainViewModel ViewModel => ViewModelLocator.Instance.MainViewModel;

        private EditText todoItemNameFromUser => FindViewById<EditText>(Resource.Id.todoItemNameFromUser);

        private Button addTodoButton => FindViewById<Button>(Resource.Id.addButton);
        private ListView todoListView => FindViewById<ListView>(Resource.Id.todoList);

        private Binding<string, string> textBinding;

        private TodoAdapter todoAdapter;

        private TodoItemRepository todoItemRepository;




        /// <summary>
        /// Called when [create]. The bindings, and commands are happening here.
        /// And the settings for the database
        /// </summary>
        /// <param name="bundle">The bundle.</param>
        protected async override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.MainView);
            todoItemRepository = TodoItemRepository.Instance;
            todoItemRepository.CreateTable();

            await ViewModel.InitAsync();
            
            todoAdapter = new TodoAdapter(this, ViewModel.TodoCollection, todoItemRepository);

            textBinding = this.SetBinding(() => todoItemNameFromUser.Text, BindingMode.TwoWay);
            
            addTodoButton.SetCommand("Click", ViewModel.AddTodoItemCommand, textBinding);

            todoListView.Adapter = todoAdapter;
        }

        protected override void OnResume()
        {
            base.OnResume();
            ViewModel.PropertyChanged += ViewModel_PropertyChanged;
        }

        /// <summary>
        /// Handles the PropertyChanged event of the ViewModel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.PropertyChangedEventArgs"/> instance containing the event data.</param>
        private void ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("SetTextViewToDefault"))
            {
                todoItemNameFromUser.SetText("",TextView.BufferType.Normal);
            }
        }

        //
        protected override void OnPause()
        {
            base.OnPause();

            if (IsFinishing)
            {
                todoItemRepository.ClearTable();
            }
        }
    }
}

