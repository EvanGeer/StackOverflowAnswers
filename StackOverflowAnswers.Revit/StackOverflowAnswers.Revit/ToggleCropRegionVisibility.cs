using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace StackOverflowAnswers.Revit
{
    [Transaction(TransactionMode.Manual)]
    internal class ToggleCropRegion : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            using (var t = new Transaction(commandData.Application.ActiveUIDocument.Document, "ToggleCropBox"))
            {
                t.Start();
                var currentView = commandData.View;
                currentView.CropBoxVisible = !currentView.CropBoxVisible;
                t.Commit();
            }


            return Result.Succeeded;
        }
    }
}
