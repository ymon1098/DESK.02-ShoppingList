using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace ShoppingListApp.Models
{
    [XmlInclude(typeof(Product))]
    public class Product : INotifyPropertyChanged
    {
        private string name;
        private string unit;
        private int quantity;
        private bool isPurchased;
        private Category category;

        public Product()
        {
        }

        public Product(Category category)
        {
            this.category = category;
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

        public string Unit
        {
            get => unit;
            set
            {
                if (unit != value)
                {
                    unit = value;
                    OnPropertyChanged();
                }
            }
        }

        public int Quantity
        {
            get => quantity;
            set
            {
                if (quantity != value)
                {
                    quantity = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsPurchased
        {
            get => isPurchased;
            set
            {
                if (isPurchased != value)
                {
                    isPurchased = value;
                    OnPropertyChanged();
                }
            }
        }

        [XmlIgnore]
        public Category Category
        {
            get => category;
            set
            {
                if (category != value)
                {
                    category = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    
        public static ObservableCollection<Product> AvailableProducts { get; set; } = new ObservableCollection<Product>
        {
            new Product(null) { Name = "Jabłka", Unit = "kg", Quantity = 1 },
            new Product(null) { Name = "Masło", Unit = "g", Quantity = 200 },
            new Product(null) { Name = "Jajka", Unit = "szt.", Quantity = 10 },
            new Product(null) { Name = "Oliwa", Unit = "ml", Quantity = 500 },
            new Product(null) { Name = "Woda", Unit = "l", Quantity = 2 }
        };
    }
}
