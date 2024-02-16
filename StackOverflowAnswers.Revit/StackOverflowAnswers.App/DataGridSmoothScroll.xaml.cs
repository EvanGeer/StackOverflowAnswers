using System.Collections.Generic;
using System.Windows;

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
