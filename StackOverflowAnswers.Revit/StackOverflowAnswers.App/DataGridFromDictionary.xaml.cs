using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Principal;
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
    /// Interaction logic for DataGridFromDictionary.xaml
    /// </summary>
    public partial class DataGridFromDictionary : Window
    {
        public DataTable Table { get; set; }
        public DataGridFromDictionary()
        {
            var attributeDictionaries = new List<Dictionary<string, string>>()
            {
                new Dictionary<string, string>()
                {
                    {"name", "john" },
                    {"age", "21" },
                    {"favourite color", "blue" },
                    {"city", "london" },
                },                new Dictionary<string, string>()
                {
                    {"name", "jane" },
                    {"favourite fruit", "ananas" },
                    {"favourite color", "red" },
                    {"city", "paris" },
                },
            };

            Table = CovertToDataTable(attributeDictionaries);

            InitializeComponent();
            DataContext = this;
        }

        public DataTable CovertToDataTable(List<Dictionary<string, string>> dynamicObjects)
        {
            DataTable table = new DataTable();

            foreach(var attributeDictionary in dynamicObjects)
            {
                // add any missing columns
                foreach (var attribute in attributeDictionary.Keys)
                {
                    if (!table.Columns.Contains(attribute))
                    {
                        table.Columns.Add(attribute);
                    }
                }

                // create the new row
                var dr = table.NewRow();

                foreach (var attribute in attributeDictionary)
                {
                    dr[attribute.Key] = attribute.Value;
                }

                table.Rows.Add(dr);
            }

            return table;
        }
    }
}
