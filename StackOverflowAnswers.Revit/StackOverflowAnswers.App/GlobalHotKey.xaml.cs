using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace StackOverflowAnswers.Wpf
{
public class CtrlLeftClickCommand : ICommand
{
    public event EventHandler CanExecuteChanged;

    public bool CanExecute(object parameter) => true;
    public void Execute(object parameter)
    {
        DoJob();
    }
    private void DoJob() => MessageBox.Show("Job Done!");
}

public class ViewModel
{
    public ICommand CtrlLeftClickCommand { get; set; } = new CtrlLeftClickCommand();
}
/// <summary>
/// Interaction logic for GlobalHotKey.xaml
/// </summary>
public partial class GlobalHotKey : Window
{
    public GlobalHotKey()
    {
        DataContext = new ViewModel();
        InitializeComponent();
    }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Keyboard.Modifiers.HasFlag(ModifierKeys.Control))
            {
                //e.Source = this;
                //e.Handled = true;
                //this.RaiseEvent(new MouseEventArgs(Mouse.PrimaryDevice, DateTime.Now.Millisecond)) ;
                return;
            }
            MessageBox.Show("Click");
        }
    }
}
