using Biing2WPF.ViewModels;
using System.Diagnostics;
using System.Windows;

namespace Biing2WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Process process = Memory.GetProcessByName("biing2");
            uint pHandle = (uint)Memory.OpenProcess(Memory.PROCESS_ALL_ACCESS, false, process.Id);
            uint baseAddress = (uint)Memory.GetModuleBaseAddress(process, "biing2.exe");

            InitializeComponent();
            DataContext = new MainViewModel(new Biing2.Biing2(pHandle, baseAddress));
        }
    }
}
