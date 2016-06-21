using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AccountManager.ViewModels;

namespace AccountManager.Views
{
    /// <summary>
    /// Interaction logic for ManageAccountPageView.xaml
    /// </summary>
    public partial class ManageAccountPageView : UserControl
    {
        public ManageAccountPageView()
        {
            InitializeComponent();
        }

        private void UIElement_OnDrop(object sender, DragEventArgs e)
        {
            var canvas = sender as Canvas;
            var vm = e.Data.GetData("viewModel") as AccountViewModel;
            canvas.Children.Add(new TextBlock {Text = vm.Account.Name});
        }

        private void UIElement_OnMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed == false)
            {
                return;
            }
            var vm = (sender as FrameworkElement).DataContext;
            DragDrop.DoDragDrop(this, new DataObject("viewModel", vm), DragDropEffects.All);
        }
    }
}
