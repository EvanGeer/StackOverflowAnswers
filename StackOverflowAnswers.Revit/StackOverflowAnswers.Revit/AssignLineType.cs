using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Linq;

namespace StackOverflowAnswers.Revit
{
    [Transaction(TransactionMode.Manual)]
    public class AssignLineType : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            var uiDoc = commandData.Application.ActiveUIDocument;
            var Document = uiDoc.Document;

            var lines = new FilteredElementCollector(Document, uiDoc.ActiveView.Id)
                .WhereElementIsNotElementType()
                .OfClass(typeof(CurveElement))
                .Cast<CurveElement>()
                .ToList();

            var graphicsStyles = new FilteredElementCollector(Document)
                .WhereElementIsNotElementType()
                .OfClass(typeof(GraphicsStyle))
                .Cast<GraphicsStyle>()
                .ToList();

            var lineStyle = graphicsStyles.FirstOrDefault(x => x.Name == "<Invisible lines>");

            if (lineStyle != null)
            {
                using (var t = new Transaction(Document, "update line type"))
                {
                    t.Start();
                    lines.ForEach(line => line.LineStyle = lineStyle);
                    t.Commit();
                }
            }

            return Result.Succeeded;
        }
    }
}
