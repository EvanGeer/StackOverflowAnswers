using System.Collections.Generic;
using System.Windows;

namespace StackOverflowAnswers.Wpf
{
    /// <summary>
    /// Interaction logic for DataGridConditionalHeaderFormat.xaml
    /// </summary>
    public partial class DataGridConditionalHeaderFormat : Window
    {
        public class dataMcData
        {
            public string Name { get; set; }
            public int Number { get; set; }
        }
        public DataGridConditionalHeaderFormat()
        {
            DataContext = new
            {
                Data = new List<dataMcData>
                {
                    new dataMcData {Name= "Test 1" , Number = 1},
                    new dataMcData {Name= "Test 2" , Number = 2},
                    new dataMcData {Name= "Test 3" , Number = 3},
                }
            };

            InitializeComponent();
        }
    }
}
