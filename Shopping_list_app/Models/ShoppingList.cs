using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace ShoppingListApp.Models
{
    [XmlInclude(typeof(Category))]
    public class ShoppingList : INotifyPropertyChanged
    {
        private string name;

        public ShoppingList()
        {
            Categories = new ObservableCollection<Category>();
        }

        public string Name
        {
            get => name;
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<Category> Categories { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
