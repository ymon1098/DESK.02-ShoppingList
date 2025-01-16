using ShoppingListApp.Models;
using ShoppingListApp.Views;
using System;
using System.Collections.ObjectModel;

namespace ShoppingListApp.Views
{
    public partial class AddShoppingListPage : ContentPage
    {
        public ObservableCollection<ShoppingList> ShoppingLists { get; set; }

        public AddShoppingListPage(ObservableCollection<ShoppingList> shoppingLists)
        {
            InitializeComponent();
            ShoppingLists = shoppingLists;
        }

        private async void AddListButton_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(ListNameEntry.Text))
            {
                var newList = new ShoppingList
                {
                    Name = ListNameEntry.Text,
                    Categories = new ObservableCollection<Category>
                    {
                        new Category { Name = "Nabia³", Products = new ObservableCollection<Product>(), IsExpanded = false },
                        new Category { Name = "Warzywa", Products = new ObservableCollection<Product>(), IsExpanded = false },
                        new Category { Name = "Elektronika", Products = new ObservableCollection<Product>(), IsExpanded = false },
                        new Category { Name = "AGD", Products = new ObservableCollection<Product>(), IsExpanded = false }
                    }
                };
                ShoppingLists.Add(newList);
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("B³¹d", "Wpisz nazwê listy zakupowej.", "OK");
            }
        }
    }
}
