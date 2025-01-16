using ShoppingListApp.Models;
using System.Collections.ObjectModel;
using System.IO;
using System.Xml.Serialization;

namespace ShoppingListApp.Services
{
    public class DataService
    {
        public void SaveShoppingLists(ObservableCollection<ShoppingList> shoppingLists, string filePath)
        {
            var serializer = new XmlSerializer(typeof(ObservableCollection<ShoppingList>));
            using (var writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, shoppingLists);
            }
        }

        public ObservableCollection<ShoppingList> LoadShoppingLists(string filePath)
        {
            if (File.Exists(filePath))
            {
                var serializer = new XmlSerializer(typeof(ObservableCollection<ShoppingList>));
                using (var reader = new StreamReader(filePath))
                {
                    return (ObservableCollection<ShoppingList>)serializer.Deserialize(reader);
                }
            }
            return new ObservableCollection<ShoppingList>();
        }

        public void ExportShoppingList(ShoppingList shoppingList, Stream fileStream)
        {
            var serializer = new XmlSerializer(typeof(ShoppingList));
            serializer.Serialize(fileStream, shoppingList);
        }

        public ShoppingList ImportShoppingList(Stream fileStream)
        {
            var serializer = new XmlSerializer(typeof(ShoppingList));
            return (ShoppingList)serializer.Deserialize(fileStream);
        }
    }
}
