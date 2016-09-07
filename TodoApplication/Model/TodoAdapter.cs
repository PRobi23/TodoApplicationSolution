using Android.Views;
using Android.Widget;
using TodoApplication.Model.Database;
using Android.App;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Collections.Specialized;
using TodoApplication.ViewModel;

namespace TodoApplication.Model
{
    class TodoAdapter : BaseAdapter
    {
        private Activity activity;
        private ObservableCollection<Todo> todoesList = new ObservableCollection<Todo>();

        public TodoAdapter(Activity activity, ObservableCollection<Todo> todoesList)
        {
            this.activity = activity;
            this.todoesList = todoesList;
            todoesList.CollectionChanged += TodoesList_CollectionChanged;
        }

        private void TodoesList_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {

            //Get the sender observable collection
            ObservableCollection<Todo> obsSender = sender as ObservableCollection<Todo>;

            List<Todo> editedOrRemovedItems = new List<Todo>();
            foreach (Todo newItem in e.NewItems)
            {
                editedOrRemovedItems.Add(newItem);
            }

            SqLiteRepository.SqLiteRepo.Insert(editedOrRemovedItems[0]);
            NotifyCollectionChangedAction action = e.Action;

            NotifyDataSetChanged();
        }

        public override int Count
        {
            get
            {
                return SqLiteRepository.SqLiteRepo.GetItemCount();
            }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return todoesList[position].TodoId;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? activity.LayoutInflater.Inflate(
                Resource.Layout.RowItem, parent, false);

            if (position < todoesList.Count)
            {
                var todoName = view.FindViewById<TextView>(Resource.Id.todoName);
                var todoCreationDate = view.FindViewById<TextView>(Resource.Id.todoCreationTime);


                todoName.Text = todoesList[position].Name;
                todoCreationDate.Text = todoesList[position].CreateTime.ToShortTimeString();

                NotifyDataSetChanged();
            }

            return view;
        }


        //public override int GetItemViewType(int position)
        //{
        // //   bool isSection = todoesList[position].IsSeparator;

        //    if (isSection)
        //    {
        //        return ITEM_VIEW_TYPE_SEPARATOR;
        //    }
        //    else
        //    {
        //        return ITEM_VIEW_TYPE_REGULAR;
        //    }
        //}

    }
}