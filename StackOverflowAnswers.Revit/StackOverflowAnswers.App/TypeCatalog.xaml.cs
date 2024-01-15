using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
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

namespace StackOverflowAnswers.App
{
    /// <summary>
    /// Interaction logic for TypeCatalog.xaml
    /// </summary>
    public partial class TypeCatalogForm : Window
    {
        public DataView Types { get; set; }

        public TypeCatalogForm()
        {
            Types = CreateDataSource();
            InitializeComponent();
            DataContext = this;
        }

        string CSVDataBase = @"c:\StackOverflow\Box.txt";

        //Create Collection for DataGrid Source
        DataView CreateDataSource()
        {
            //Create new DataTables and Rows
            DataTable dt = new DataTable();
            dt.Columns.Add("Selected", typeof(bool));
            DataRow dr;

            bool firstRow = true;
            var lines = File.ReadLines(CSVDataBase);
            //For each line in the File
            foreach (string Line in lines)
            {
                var cols = Line.Split(',');
                if (firstRow) // first row is the headers
                {
                    bool firstCol = true;
                    foreach (var col in cols)
                    {
                        if (firstCol)
                        {
                            firstCol = false;
                            dt.Columns.Add("Type"); // first column doesn't have a header in the text file
                            continue;
                        }

                        // the headers have a lot of extra stuff we don't care about
                        string cleanedHeader = col.Split('#')[0].Split('[')[0];
                        dt.Columns.Add(cleanedHeader);
                    }

                    firstRow = false;
                    continue;
                }


                //Create new Row
                dr = dt.NewRow();
                for (var i = 0; i < cols.Length - 1; i++)
                {
                    dr[i+1] = cols[i];
                }
                dt.Rows.Add(dr);
            }

            //Return Dataview 
            DataView dv = new DataView(dt);
            return dv;
        }
    }
}
