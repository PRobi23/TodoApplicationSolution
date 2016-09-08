using Android.Views;
using Android.Widget;
using TodoApplication.Model.Database;
using Android.App;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace TodoApplication.Model
{
    /// <summary>
    /// It's an adapter pattern.
    /// I use it becouse it's much more flexible, than just the existing ones in the Android system.
    /// </summary>
    /// <seealso cref="Android.Widget.BaseAdapter" />
    class TodoAdapter : BaseAdapter
    {
        private Activity activity;
        private ObservableCollection<Todo> todoesList = new ObservableCollection<Todo>();
        private IRepository todoItemRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="TodoAdapter"/> class.
        /// </summary>
        /// <param name="activity">The activity.</param>
        /// <param name="todoesList">The todoes list.</param>
        /// <param name="iRepository">The i repository.</param>
        public TodoAdapter(Activity activity, ObservableCollection<Todo> todoesList, IRepository iRepository)
        {
            this.activity = activity;
            this.todoesList = todoesList;
            todoItemRepository = iRepository;
            todoesList.CollectionChanged += TodoesList_CollectionChanged;
        }

        /// <summary>
        /// Handles the CollectionChanged event of the TodoesList control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="NotifyCollectionChangedEventArgs"/> instance containing the event data.</param>
        private void TodoesList_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {

            //Get the sender observable collection
            ObservableCollection<Todo> obsSender = sender as ObservableCollection<Todo>;

            List<Todo> editedOrRemovedItems = new List<Todo>();
            foreach (Todo newItem in e.NewItems)
            {
                editedOrRemovedItems.Add(newItem);
                todoItemRepository.Insert(newItem);
            }

            NotifyCollectionChangedAction action = e.Action;

            NotifyDataSetChanged();
        }

        /// <summary>
        /// To be added.
        /// </summary>
        /// <value>
        /// To be added.
        /// </value>
        /// <remarks>
        /// To be added.
        /// </remarks>
        public override int Count
        {
            get
            {
                return todoItemRepository.GetItemCount();
            }
        }

        /// <summary>
        /// To be added.
        /// </summary>
        /// <param name="position">To be added.</param>
        /// <returns>
        /// To be added.
        /// </returns>
        /// <remarks>
        /// To be added.
        /// </remarks>
        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        /// <summary>
        /// To be added.
        /// </summary>
        /// <param name="position">To be added.</param>
        /// <returns>
        /// To be added.
        /// </returns>
        /// <remarks>
        /// To be added.
        /// </remarks>
        public override long GetItemId(int position)
        {
            return todoesList[position].TodoId;
        }

        /// <summary>
        /// To be added.
        /// </summary>
        /// <param name="position">To be added.</param>
        /// <param name="convertView">To be added.</param>
        /// <param name="parent">To be added.</param>
        /// <returns>
        /// To be added.
        /// </returns>
        /// <remarks>
        /// To be added.
        /// </remarks>
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            MyViewHolder holder;
            var view = convertView;

            if (view == null)
            {
                holder = new MyViewHolder();
                view = activity.LayoutInflater.Inflate(Resource.Layout.RowItem, null);
                holder.Name = view.FindViewById<TextView>(Resource.Id.todoName);
                holder.CreateDate = view.FindViewById<TextView>(Resource.Id.todoCreationDate);
                holder.CreateTime = view.FindViewById<TextView>(Resource.Id.todoCreationTime);

                view.Tag = holder;
            }
            holder = view.Tag as MyViewHolder;

            holder.Name.Text = todoesList[position].Name;
            holder.CreateDate.Text = todoesList[position].CreateTime.ToShortDateString();
            holder.CreateTime.Text = todoesList[position].CreateTime.ToLongTimeString();

            return view;
        }



        /// <summary>
        /// A ViewHolder class for better memory management.
        /// </summary>
        /// <seealso cref="Java.Lang.Object" />
        private class MyViewHolder : Java.Lang.Object
        {
            public TextView Name { get; set; }
            public TextView CreateDate { get; set; }

            public TextView CreateTime { get; set; }
        }

    }
}