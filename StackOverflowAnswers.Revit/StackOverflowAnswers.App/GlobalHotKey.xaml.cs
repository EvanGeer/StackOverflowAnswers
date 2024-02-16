using System;
using System.Windows;
using System.Windows.Input;

namespace StackOverflowAnswers.Wpf
{
    public class CtrlLeftClickCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => true;
        public void Execute(object parameter) => DoJob();
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
