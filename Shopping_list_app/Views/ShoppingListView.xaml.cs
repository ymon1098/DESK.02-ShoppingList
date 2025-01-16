using ShoppingListApp.Models;
using ShoppingListApp.Services;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace ShoppingListApp.Views
{
    public partial class ShoppingListView : ContentPage
    {
        private readonly DataService _dataService;

        public ShoppingList ShoppingList { get; set; }

        public ShoppingListView(ShoppingList shoppingList)
        {
            InitializeComponent();
            ShoppingList = shoppingList;
            _dataService = new DataService();
            BindingContext = ShoppingList;
        }

        private async void AddProductButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddProductPage(ShoppingList));
        }

        private async void AddCategoryButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddCategoryPage(ShoppingList));
        }

        private void SaveShoppingList()
        {
            try
            {
                string filePath = Path.Combine(FileSystem.AppDataDirectory, "ShoppingLists.xml");
                var shoppingLists = new ObservableCollection<ShoppingList> { ShoppingList };
                _dataService.SaveShoppingLists(shoppingLists, filePath);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error saving shopping list: {ex.Message}");
            }
        }
    }
}
