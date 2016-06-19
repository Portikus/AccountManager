using System.Windows;
using AccountManager.ViewModels;
using Microsoft.Practices.Unity;
using Prism.Logging;
using Prism.Unity;

namespace AccountManager
{
    internal class Bootstrapper : UnityBootstrapper
    {
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
        }

        protected override DependencyObject CreateShell()
        {
            return new Shell(); 
        }

        protected override void InitializeShell()
        {
            var shell = ((Window)Shell);
            shell.DataContext = Container.Resolve<ShellViewModel>();
            Application.Current.MainWindow = shell;
            shell.Show();
        }

        protected override ILoggerFacade CreateLogger()
        {
            return new DebugLogger();
        }
    }
}
