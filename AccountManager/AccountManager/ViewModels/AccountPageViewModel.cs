using System;
using System.CodeDom;
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
    public class AccountPageViewModel : BindableBase
    {
        private readonly FinanceDatabase _database;
        private readonly IUnityContainer _container;

        public ObservableCollection<AccountViewModel> AccountViewModels { get; set; }

        public AccountViewModel AccountViewModel { get; set; }

        public AccountPageViewModel(FinanceDatabase database, IUnityContainer container)
        {
            _database = database;
            _container = container;
            AccountViewModels = new ObservableCollection<AccountViewModel>(CreateAccountViewModels(_database.Accounts));
        }

        private IEnumerable<AccountViewModel> CreateAccountViewModels(IEnumerable<Account> accounts)
        {
            foreach (var account in accounts)
            {
                var vm = _container.Resolve<AccountViewModel>();
                vm.Account = account;
                yield return vm;
            }
        }
    }
}
