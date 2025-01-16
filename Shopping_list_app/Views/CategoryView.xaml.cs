using ShoppingListApp.Models;

namespace ShoppingListApp.Views
{
    public partial class CategoryView : ContentView
    {
        public CategoryView()
        {
            InitializeComponent();
        }

        private void ToggleExpand(object sender, EventArgs e)
        {
            var category = (Category)BindingContext;
            category.IsExpanded = !category.IsExpanded;
        }
    }
}