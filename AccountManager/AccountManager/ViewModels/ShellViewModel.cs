using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountManager.DataContext;
using AccountManager.Entities;
using Microsoft.Practices.Unity;
using Prism.Mvvm;

namespace AccountManager.ViewModels
{
    public class ShellViewModel : BindableBase
    {
        public ObservableCollection<Account> Accounts { get; set; }

        public AccountViewModel AccountViewModel { get; set; }

        private readonly FinanceDatabase _database;

        public ShellViewModel(FinanceDatabase database, AccountViewModel accountViewModel)
        {
            AccountViewModel = accountViewModel;
            _database = database;
            Accounts = new ObservableCollection<Account>(_database.Accounts);
        }
    }
}
