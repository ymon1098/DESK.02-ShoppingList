using ShoppingListApp.Models;
using ShoppingListApp.Views;
using System.Collections.ObjectModel;
using System.IO;
using ShoppingListApp.Services;
using System.Diagnostics;

namespace ShoppingListApp
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<ShoppingList> ShoppingLists { get; set; }
        private readonly DataService _dataService;
        private readonly string _filePath;

        public MainPage()
        {
            InitializeComponent();
            ShoppingLists = new ObservableCollection<ShoppingList>();
            BindingContext = this;
            _dataService = new DataService();
            _filePath = Path.Combine(FileSystem.AppDataDirectory, "ShoppingLists.xml");

            LoadShoppingLists();

            if (ShoppingLists.Count == 0)
            {
                AddPredefinedShoppingLists();
            }
        }

        private void LoadShoppingLists()
        {
            try
            {
                Debug.WriteLine($"Loading shopping lists from: {_filePath}");
                var loadedLists = _dataService.LoadShoppingLists(_filePath);
                if (loadedLists != null)
                {
                    ShoppingLists = new ObservableCollection<ShoppingList>(loadedLists);
                    Debug.WriteLine($"Loaded {ShoppingLists.Count} shopping lists.");
                    RefreshUI();
                }
                else
                {
                    Debug.WriteLine("No shopping lists loaded.");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error loading shopping lists: {ex.Message}");
            }
        }

        private void SaveShoppingLists()
        {
            try
            {
                Debug.WriteLine($"Saving shopping lists to: {_filePath}");
                _dataService.SaveShoppingLists(ShoppingLists, _filePath);
                Debug.WriteLine($"Saved {ShoppingLists.Count} shopping lists.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error saving shopping lists: {ex.Message}");
            }
        }

        private void AddPredefinedShoppingLists()
        {
            var predefinedList = new ShoppingList
            {
                Name = "Predefiniowana lista",
                Categories = new ObservableCollection<Category>
                {
                    new Category { Name = "Nabiał", Products = new ObservableCollection<Product>(), IsExpanded = false },
                    new Category { Name = "Warzywa", Products = new ObservableCollection<Product>(), IsExpanded = false },
                    new Category { Name = "Elektronika", Products = new ObservableCollection<Product>(), IsExpanded = false },
                    new Category { Name = "AGD", Products = new ObservableCollection<Product>(), IsExpanded = false }
                }
            };

            ShoppingLists.Add(predefinedList);
            SaveShoppingLists();
            Debug.WriteLine($"Added predefined shopping list. Total lists: {ShoppingLists.Count}");
            RefreshUI();
        }

        private async void AddShoppingListButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddShoppingListPage(ShoppingLists));
        }

        private async void OpenShoppingListButton_Clicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var selectedList = (ShoppingList)button.CommandParameter;
            await Navigation.PushAsync(new ShoppingListView(selectedList));
        }

        private async void DeleteShoppingListButton_Clicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var selectedList = (ShoppingList)button.CommandParameter;
            ShoppingLists.Remove(selectedList);
            SaveShoppingLists();
            RefreshUI();
            await DisplayAlert("Usuwanie", "Lista zakupowa została usunięta.", "OK");
        }

        private void RefreshUI()
        {
            OnPropertyChanged(nameof(ShoppingLists));
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            SaveShoppingLists();
        }
    }
}
