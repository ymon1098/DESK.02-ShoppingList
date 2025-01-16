using Microsoft.Maui.Graphics.Text;
using ShoppingListApp.Models;
using System;

namespace ShoppingListApp.Views
{
    public partial class ProductView : ContentView
    {
        public ProductView()
        {
            InitializeComponent();
        }

        private void IncreaseQuantity(object sender, EventArgs e)
        {
            var product = (Product)BindingContext;
            product.Quantity++;
        }

        private void DecreaseQuantity(object sender, EventArgs e)
        {
            var product = (Product)BindingContext;
            if (product.Quantity > 0)
                product.Quantity--;
        }

        private void DeleteProduct(object sender, EventArgs e)
        {
            var product = (Product)BindingContext;
            var category = (Category)((ContentView)Parent).BindingContext;
            category.Products.Remove(product);
        }

        private void OnPurchasedChanged(object sender, CheckedChangedEventArgs e)
        {
            var product = (Product)BindingContext;
            product.IsPurchased = e.Value;

            var label = (Label)this.FindByName("ProductLabel");
            if (label != null)
            {
                var formattedString = new FormattedString();
                formattedString.Spans.Add(new Span
                {
                    Text = product.Name,
                    FontSize = 20,
                    FontAttributes = FontAttributes.Bold,
                    TextDecorations = product.IsPurchased ? TextDecorations.Strikethrough : TextDecorations.None
                });
                formattedString.Spans.Add(new Span
                {
                    Text = "        "
                });
                formattedString.Spans.Add(new Span
                {
                    Text = $"Iloœæ: {product.Quantity}",
                    FontSize = 14,
                    TextDecorations = product.IsPurchased ? TextDecorations.Strikethrough : TextDecorations.None
                });
                formattedString.Spans.Add(new Span
                {
                    Text = product.Unit,
                    FontSize = 14,
                    TextDecorations = product.IsPurchased ? TextDecorations.Strikethrough : TextDecorations.None
                });
                label.FormattedText = formattedString;
            }
        }
    }
}
