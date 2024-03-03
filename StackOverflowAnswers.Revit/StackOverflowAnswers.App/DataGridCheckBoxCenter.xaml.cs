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
    /// Interaction logic for DataGridCheckBoxCenter.xaml
    /// </summary>
    public partial class DataGridCheckBoxCenter : Window
    {
        public List<bool> Data = new List<bool>()
        {
            true,
            false,
            true,
            true,
            true,
            false,
            false,
        };

        public DataGridCheckBoxCenter()
        {
            DataContext = this;
            InitializeComponent();
        }
    }
}
