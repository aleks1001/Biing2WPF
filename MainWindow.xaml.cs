using BMF.Main;
using System.Diagnostics;
using System.Windows;
using MyBiing2.Repository;

namespace MyBiing2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            Process process = Memory.GetProcessByName("biing2");
            int pHandle = (int)Memory.OpenProcess(Memory.PROCESS_ALL_ACCESS, false, process.Id);
            int baseAddress = (int)Memory.GetModuleBaseAddress(process, "biing2.exe");

            Biing2 game = new(pHandle, baseAddress);
            DataContext = new MainWindowViewModel(game);
            InitializeComponent();
        }
    }
}
