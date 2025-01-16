using System.Collections.ObjectModel;
using ShoppingListApp.Models;


namespace ShoppingListApp.Views
{
    public partial class AddCategoryPage : ContentPage
    {
        public ShoppingList ShoppingList { get; set; }

        public AddCategoryPage(ShoppingList shoppingList)
        {
            InitializeComponent();
            ShoppingList = shoppingList;
        }

        private async void AddCategoryButton_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(CategoryNameEntry.Text))
            {
                var newCategory = new Category
                {
                    Name = CategoryNameEntry.Text,
                    Products = new ObservableCollection<Product>(),
                    IsExpanded = false
                };
                ShoppingList.Categories.Add(newCategory);
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("B³¹d", "Wpisz nazwê kategorii.", "OK");
            }
        }
    }
}

