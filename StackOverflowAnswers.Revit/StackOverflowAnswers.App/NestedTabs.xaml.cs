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
using System.Windows.Shapes;

namespace StackOverflowAnswers.Wpf
{
    /// <summary>
    /// Interaction logic for NestedTabs.xaml
    /// </summary>
    public partial class NestedTabs : Window
    {
        RoutedCommand CtrlTabCommand { get; set; }
        public NestedTabs()
        {
            CtrlTabCommand = new RoutedCommand();
            DataContext = this;
            InitializeComponent();
        }

        private void TabControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control 
                && e.Key == Key.Tab)
            {
                ParentTabs.RaiseEvent(e);
                e.Handled = true;
            }
        }
    }
}
