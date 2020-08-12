using ChatterBot.Data;
using ChatterBot.UI.ViewModels;
using System.ComponentModel;
using System.Linq;

namespace ChatterBot.UI
{
    public partial class AccountsWindow
    {
        private readonly IDataStore _dataStore;
        private readonly AccountsViewModel _accountsViewModel;

        public AccountsWindow(AccountsViewModel accountsViewModel, IDataStore dataStore)
        {
            _dataStore = dataStore;
            _accountsViewModel = accountsViewModel;
            DataContext = accountsViewModel;
            InitializeComponent();
        }

        private void AccountsWindow_OnClosing(object sender, CancelEventArgs e)
        {
            var credentials = _accountsViewModel.MenuItems.Select(x => x.Credentials);
            _dataStore.SaveEntities(credentials);
        }
    }
}
