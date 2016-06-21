using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
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
        [Dependency]
        public AccountPageViewModel AccountPageViewModel { get; set; }

        [Dependency]
        public ManageAccountPageViewModel ManageAccountPageViewModel { get; set; }
    }
}
