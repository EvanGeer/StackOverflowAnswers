using System.Windows;
using System.Windows.Input;

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
