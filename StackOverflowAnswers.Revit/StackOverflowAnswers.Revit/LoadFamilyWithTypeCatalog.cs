using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using StackOverflowAnswers.App;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace StackOverflowAnswers.Revit
{



    [Transaction(TransactionMode.Manual)]
    public class LoadFamilyWithTypeCatalog_PostCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            var commandId = RevitCommandId.LookupCommandId("ID_FAMILY_LOAD");
            commandData.Application.PostCommand(commandId);

            return Result.Succeeded;
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class IsWallCutByLevel : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            ViewPlan viewPlan = null;
            var viewRange = viewPlan.GetViewRange();
            Level cutLevel = null; // The cut level of the view
            var walls = new List<Wall>();

            foreach (var wall in walls) // Assuming we have a list of walls
            {
                var wallTop = wall.get_BoundingBox(viewPlan).Min.Z;
                var wallBase = wall.get_BoundingBox(viewPlan).Max.Z;

                if (wallBase < cutLevel.Elevation && wallTop > cutLevel.Elevation)
                {
                    // The wall is displayed as cut
                }
                else
                {
                    // The wall is displayed in full or not displayed
                }
            }

            return Result.Succeeded;
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class LoadFamilyWithTypeCatalog_CustomUI : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            var doc = commandData.Application.ActiveUIDocument.Document;

            var path = @"C:\StackOverflow\Box.rfa";

            using (var t = new Transaction(doc, "Load Family"))
            {
                t.Start();

                var typeCatalogForm = new TypeCatalogForm();
                typeCatalogForm.ShowDialog();

                // Load Selected Symbols
                var selectedSymbolNames = typeCatalogForm.Types.Table.Rows
                    .OfType<DataRow>()
                    .Where(x => x[0] is bool selected && selected)
                    .Select(x => x["Type"] as string)
                    .ToHashSet();

                foreach (var type in selectedSymbolNames)
                {
                    doc.LoadFamilySymbol(path, type);
                }

                t.Commit();
            }

            return Result.Succeeded;
        }
    }


    //var defaultSymbol = loadedSymbols.FirstOrDefault();

    // add any missing symbols that were selected
    //foreach (DataRow row in typeCatalogForm.Types.Table.Rows)
    //{
    //    var isSelected = (bool)row[0];
    //    if (!isSelected) continue;

    //    var typeName = row["Type"] as string;

    //    if (loadedSymbols.Any(x => x.Name == typeName)) continue;

    //    var newSymbol = defaultSymbol.Duplicate(typeName);
    //    foreach (DataColumn col in row.Table.Columns)
    //    {
    //        if (col.ColumnName == "Type") continue;

    //        newSymbol.LookupParameter(col.ColumnName)?.Set(row[col] as string);
    //    }
    //}
}
