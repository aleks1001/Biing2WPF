using System.Collections.ObjectModel;
using MyBiing2.Models;
using MyBiing2.Repository;

namespace MyBiing2.Property
{
    public class GameBuildingViewListModel : BindableBase
    {
        public Biing2 b { get; set; }

        public GameBuildingViewListModel(Biing2 b)
        {
            this.b = b;
        }

        public ObservableCollection<GameBuilding> Buildings { get; } = new();

        public async void GetGameBuildingsAsync()
        {
            var buildings = await b.GetGameBuildingsAsync();
            for (var i = 1; i < buildings.Length; i++)
            {
                Buildings.Add(new GameBuilding(i, buildings[i], b));
            }
        }
    }
}
