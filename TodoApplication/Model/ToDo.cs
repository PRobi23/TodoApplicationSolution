
using SQLite.Net.Attributes;
using System;
using TodoApplication.Model.Database;
using System.ComponentModel;
using GalaSoft.MvvmLight;

namespace TodoApplication.Model
{
    public class Todo : ObservableObject
    {
        private IRepository repository;

        [PrimaryKey, AutoIncrement]
        public int TodoId { get; set; }


        private string name;

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                RaisePropertyChanged("Name");
            }
        }

        /// <summary>
        /// Gets or sets the create time.
        /// </summary>
        /// <value>
        /// The create time.
        /// </value>
        public DateTime CreateTime { get; set; }


        //private bool isSeparator;

        //public bool IsSeparator
        //{
        //    get { return isSeparator; }
        //    set { isSeparator = value; }
        //}


        /// <summary>
        /// Initializes a new instance of the <see cref="Todo"/> class.
        /// </summary>
        public Todo(IRepository repository)
        {
            this.repository = repository;
        }
        public Todo()
        {

        }

        public override string ToString()
        {
            return $"Todo: {name}";
            //CreateTime.ToLongDateString() + CreateTime.ToShortTimeString()}
        }

    }
}