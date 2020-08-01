using ChatterBot.ViewModels;

namespace ChatterBot
{
    public partial class AccountsWindow
    {
        public AccountsWindow(AccountsViewModel accountsViewModel)
        {
            DataContext = accountsViewModel;
            InitializeComponent();
        }
    }
}
