using BMF.Main;
using System.Diagnostics;
using System.Windows;

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
            uint pHandle = (uint)Memory.OpenProcess(Memory.PROCESS_ALL_ACCESS, false, process.Id);
            uint baseAddress = (uint)Memory.GetModuleBaseAddress(process, "biing2.exe");
            DataContext = new MainWindowViewModel(new Repository.Biing2(pHandle, baseAddress));
            //InitializeComponent();
        }
    }
}
