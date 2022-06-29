using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace boxrec
{
    internal class BoxerViewModel : ObservableObject, IDataErrorInfo
    {
        /// <summary>
        /// string <c>Error</c> implemented by interface, not used in the program
        /// </summary>
        public string Error { get { return null; } }

        private string? _name;
        private string? _surname;

        /// <summary>
        /// Dictionary <c>ErrorColection</c> Stores error messages
        /// </summary>

        public Dictionary<string, string> ErrorCollection { get; private set; } = new Dictionary<string, string>();

        /// <summary>
        /// string <c>this</c> Indexer verify if inserted name is null or empty
        /// </summary>
        public string this[string name]
        {
            get
            {
                string result = null;

                switch (name)
                {
                    case "Name":
                        if (string.IsNullOrWhiteSpace(Name))
                            result = "Name cannot be empty.";
                        break;

                    case "Surname":
                        if (string.IsNullOrWhiteSpace(Surname))
                            result = "Surname cannot be empty.";
                        break;

                }

                if (ErrorCollection.ContainsKey(name))
                    ErrorCollection[name] = result;
                else if (result != null)
                    ErrorCollection.Add(name, result);

                OnPropertyChanged("ErrorCollection");
                return result;
            }
        }
        /// <summary>
        /// string <c>Name</c> Set private string? _name; when data is inserted to the TextBox
        /// </summary>
        public string Name
        {
            get { return _name; }
            set
            {
                OnPropertyChanged(ref _name, value);
            }
        }
        /// <summary>
        /// string <c>Surname</c> Set private string? _surname; when data is inserted to the TextBox
        /// </summary>
        public string Surname
        {
            get { return _surname; }
            set
            {
                OnPropertyChanged(ref _surname, value);
            }
        }

    }
}
