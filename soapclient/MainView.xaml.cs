using System.Windows;
using ViewModel;

namespace soapclient
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
            
            var viewModel = new MainViewModel();
            Closed += viewModel.OnViewClosing;
            DataContext = viewModel;

        }
    }
}
