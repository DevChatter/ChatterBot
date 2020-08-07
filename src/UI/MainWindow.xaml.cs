using ChatterBot.ViewModels;

namespace ChatterBot
{
    public partial class MainWindow
    {
        public MainWindow(MainViewModel mainViewModel)
        {
            DataContext = mainViewModel;
            InitializeComponent();
        }
    }
}
