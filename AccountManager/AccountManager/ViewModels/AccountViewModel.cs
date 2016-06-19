using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountManager.Entities;
using Prism.Mvvm;

namespace AccountManager.ViewModels
{
    public class AccountViewModel : BindableBase
    {
        private Account _selectedAccount;

        public Account SelectedAccount
        {
            get { return _selectedAccount; }
            set
            {
                _selectedAccount = value;
                OnPropertyChanged();
            }
        }
    }
}
