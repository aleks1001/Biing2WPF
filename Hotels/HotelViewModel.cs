using MyBiing2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBiing2.Hotels
{
    public class HotelViewModel : BindableBase
    {
        public string Name { get; set; }
        public int HotelId { get; set; }

        public HotelViewModel(Hotel h)
        {
            Name = h.Money.ToString();
            HotelId = h.HotelId;
        }
    }
}
