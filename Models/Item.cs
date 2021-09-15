using BMF.Readers;
using BMF.Structs;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MyBiing2.Models
{
    public class Item: INotifyPropertyChanged
    {
        #region private members
        private int nameIndex;
        private int pictureIndex;
        #endregion
        public Item(int index, uint pHandle, uint baseAddress)
        {
            MemoryItem item = ItemReader.GetMemoryItem(pHandle, baseAddress, index);
            Index = index;
            NameIndex = item.name;
            PictureIndex = item.picId;
        }
        #region public properties
        public int Index { get; set; }
        public int NameIndex
        {
            get => nameIndex;
            set
            {
                if (value == nameIndex)
                {
                    return;
                }
                nameIndex = value;
                OnPropertyChanged();
            }
        }
        public int PictureIndex
        {
            get => pictureIndex;
            set
            {
                if (value == pictureIndex)
                {
                    return;
                }
                pictureIndex = value;
                OnPropertyChanged();
            }
        }
        #endregion
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
