using System.Data;
using System.IO;
using System.Windows;

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
            var dt = new DataTable();
            dt.Columns.Add("Selected", typeof(bool));
            DataRow dr;

            var firstRow = true;
            var lines = File.ReadLines(CSVDataBase);
            //For each line in the File
            foreach (var Line in lines)
            {
                var cols = Line.Split(',');
                if (firstRow) // first row is the headers
                {
                    var firstCol = true;
                    foreach (var col in cols)
                    {
                        if (firstCol)
                        {
                            firstCol = false;
                            dt.Columns.Add("Type"); // first column doesn't have a header in the text file
                            continue;
                        }

                        // the headers have a lot of extra stuff we don't care about
                        var cleanedHeader = col.Split('#')[0].Split('[')[0];
                        dt.Columns.Add(cleanedHeader);
                    }

                    firstRow = false;
                    continue;
                }


                //Create new Row
                dr = dt.NewRow();
                for (var i = 0; i < cols.Length - 1; i++)
                {
                    dr[i + 1] = cols[i];
                }
                dt.Rows.Add(dr);
            }

            //Return Dataview 
            var dv = new DataView(dt);
            return dv;
        }
    }
}
