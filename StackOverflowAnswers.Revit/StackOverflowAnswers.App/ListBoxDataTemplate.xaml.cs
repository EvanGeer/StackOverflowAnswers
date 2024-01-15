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
    /// Interaction logic for ListBoxDataTemplate.xaml
    /// </summary>
    public partial class ListBoxDataTemplate : Window
    {
        public List<string> Data { get; } =  new List<string>
        {
            "sample string",
            "longer sample string",
            "sample a bit longer string",
            "sample string",
            "longer sample string",
            "sample a bit longer string",
            "sample string",
            "longer sample string",
            "sample a bit longer string",
            "sample string",
            "longer sample string",
            "sample a bit longer string",
        };
        public ListBoxDataTemplate()
        {
            DataContext = this;
            InitializeComponent();
        }
    }
}
