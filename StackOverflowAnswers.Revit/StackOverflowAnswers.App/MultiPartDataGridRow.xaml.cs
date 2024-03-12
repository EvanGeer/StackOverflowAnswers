using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for MultiPartDataGridRow.xaml
    /// </summary>
    public partial class MultiPartDataGridRow : Window
    {
        public MultiPartDataGridRow()
        {
            InitializeComponent();

            ViewModel vm = new();

            MyDataGrid.DataContext = vm.Table.DefaultView;
            MyDataGrid.IsReadOnly = true;
        }

        public class DataItemViewModel
        {
            public int prop1 { get; set; }
            public int prop2 { get; set; }
            public int prop3 { get; set; }
        }

        public class ViewModel
        {
            public DataTable Table { get; init; }

            public ViewModel()
            {
                Table = new DataTable();

                Table.Columns.Add("c0");
                Table.Columns.Add("c1", typeof(IList));
                Table.Columns.Add("c2", typeof(IList));
                Table.Columns.Add("c3", typeof(IList));

                for (int i = 1; i <= 3; i++)
                {
                    DataRow row = Table.NewRow();

                    row[0] = "r" + i;
                    row[1] = new List<int>() { 10 * i, 20 * i, 25 * i };
                    row[2] = new List<int>() { 12 * i, 26 * i, 30 * i };
                    row[3] = new List<int>() { 16 * i, 28 * i, 36 * i };

                    Table.Rows.Add(row);
                }
            }
        }

private void MyDataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
{
    if (e.Column.Header == "c0")
    {
                e.Column.Header = "";
    }
    if (!e.PropertyType.IsAssignableFrom(typeof(IList))) return;

    // create a new column
    var newColumn = new DataGridTemplateColumn();
    newColumn.Header = e.Column.Header;
            
    // create a new binding
    var binding = new Binding(e.PropertyName);
    binding.Mode = BindingMode.TwoWay;

    // setup the cell template
    var elementFactory = new FrameworkElementFactory(typeof(ListBox));
    elementFactory.SetValue(ListBox.ItemsSourceProperty, binding);
    var newCellTemplate = new DataTemplate();
    newCellTemplate.VisualTree = elementFactory;
    newColumn.CellTemplate = newCellTemplate;
            
    // assign the new column
    e.Column = newColumn;
}
    }
}