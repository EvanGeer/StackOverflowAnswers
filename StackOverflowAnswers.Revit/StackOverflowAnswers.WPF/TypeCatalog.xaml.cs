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

namespace StackOverflowAnswers.WPF
{
    /// <summary>
    /// Interaction logic for TypeCatalog.xaml
    /// </summary>
    public partial class TypeCatalog : Window
    {
        public ICollection Types;
        public TypeCatalog()
        {
            Types = CreateDataSource();
            InitializeComponent();
        }

        string CSVDataBase = @"C:\CSVDatabase.csv";

        //Create Collection for DataGrid Source
        ICollection CreateDataSource()
        {
            //Create new DataTables and Rows
            DataTable dt = new DataTable();
            DataRow dr;

            //Create Column Headers


            bool firstRow = true;
            //For each line in the File
            foreach (string Line in File.ReadLines(CSVDataBase))
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

                        dt.Columns.Add(col);
                    }

                    firstRow = false;
                    continue;
                }

                //Split lines at delimiter ';''
                dr = dt.NewRow();

                //Create new Row
                for (var i = 0; i < cols.Length; i++)
                {
                    dr[i] = cols[i];
                }
                dt.Rows.Add(dr);
            }

            //Return Dataview 
            DataView dv = new DataView(dt);
            return dv;
        }
    }
}
