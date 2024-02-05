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
    /// Interaction logic for DataGridSmoothScroll.xaml
    /// </summary>

    public partial class DataGridSmoothScroll : Window
    {
        public List<string> List { get; set; } = new List<string>
        {
            "Item 1",
            "Item 1",
            "Item 1",
            "Item 1",
            "Item 1",
            "Item 1",
            "Item 1",
            "Item 1",
            "Item 1",
            "Item 1",
            "Item 1",
            "Item 1",
            "Item 1",
            "Item 1",
            "Item 1",
            "Item 1",
            "Item 1",
            "Item 1",
            "Item 1",
            "Item 1",
            "Item 1",
            "Item 1",
            "Item 1",
            "Item 1",
            "Item 1",
            "Item 1",
            "Item 1",
            "Item 1",
            "Item 1",
            "Item 1",
            "Item 1",
            "Item 1",
            "Item 1",
            "Item 1",
            "Item 1",
            "Item 1",
            "Item 1",
            "Item 1",
            "Item 1",
            "Item 1",
            "Item 1",
            "Item 1",
            "Item 1",
            "Item 1",
            "Item 1",
        };
        public DataGridSmoothScroll()
        {
            DataContext = this;
            InitializeComponent();
        }
    }
}
