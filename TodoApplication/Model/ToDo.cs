
using SQLite.Net.Attributes;
using System;
using TodoApplication.Model.Database;
using GalaSoft.MvvmLight;

namespace TodoApplication.Model
{
    /// <summary>
    /// The model for the todo object.
    /// </summary>
    /// <seealso cref="GalaSoft.MvvmLight.ObservableObject" />
    public class Todo : ObservableObject
    {
        /// <summary>
        /// Gets or sets the todo identifier.
        /// </summary>
        /// <value>
        /// The todo identifier.
        /// </value>
        [PrimaryKey, AutoIncrement]
        public int TodoId { get; set; }



        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the create time. It cannot be setted by the user, the system nows when did the user
        /// add the Todo Item.
        /// </summary>
        /// <value>
        /// The create time.
        /// </value>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Todo"/> class.
        /// </summary>
        public Todo()
        {

        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        /// <remarks>
        /// To be added.
        /// </remarks>
        public override string ToString()
        {
            return $"Todo: {Name}, {CreateTime}";
        }

    }
}