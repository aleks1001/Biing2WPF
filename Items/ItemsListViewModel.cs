using MyBiing2.Models;
using MyBiing2.Repository;
using System.Collections.ObjectModel;

namespace MyBiing2.Items
{
    public class ItemsListViewModel : BindableBase
    {
        public Biing2 b { get; set; }

        //public ObservableCollection<Item> Items { get; } = new();
        public ObservableCollection<Object50> Objects50 { get; } = new();

        public ItemsListViewModel(Biing2 b)
        {
            this.b = b;
        }

        public async void GetItemsAsync()
        {
            //var items = await b.GetItemsAsync();
            //for (var i = 1; i < items.Length; i++)
            //{
            //    Items.Add(new Item(i, items[i], b));
            //}
            if (Objects50.Count == 0)
            {
                var objects50 = await b.GetObjects50Async();
                for (var i = 0; i < objects50.Length; i++)
                {
                    Objects50.Add(new Object50(i, b));
                }
            }
        }
    }
}
