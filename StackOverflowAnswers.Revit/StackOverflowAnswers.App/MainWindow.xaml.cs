using StackOverflowAnswers.Wpf;
using System.Windows;

namespace StackOverflowAnswers.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var x = new DataGridFromDictionary();
            x.Show();
        }
    }
}