using System.Windows;
using AssemblyBrowser.ViewModel;

namespace AssemblyBrowser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ApplicationViewModel viewmodel = new ApplicationViewModel();
        }
    }
}
