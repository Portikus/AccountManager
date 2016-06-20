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
        private Account _account;

        public Account Account
        {
            get { return _account; }
            set
            {
                _account = value;
                OnPropertyChanged();
            }
        }
    }
}
