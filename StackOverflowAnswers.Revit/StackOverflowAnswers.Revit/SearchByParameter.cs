using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StackOverflowAnswers.Revit
{
    [Transaction(TransactionMode.Manual)]
    internal class SearchByParameter : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            var doc = commandData.Application.ActiveUIDocument.Document;
            var view = commandData.Application.ActiveUIDocument.ActiveView;


            using (var t = new Transaction(doc, "Add filter"))
            {
                t.Start();

                var parameter = new FilteredElementCollector(doc)
                    .OfClass(typeof(SharedParameterElement))
                    .OfType<SharedParameterElement>()
                    .Where(x => x.GuidValue == new Guid("cf973001-e6e2-4e80-b502-ff74918165c9")) // if you know the GUID
                    .Where(x => x.Name == "MySharedParam") // if you know the name
                    .FirstOrDefault();

                var filterRule = ParameterFilterRuleFactory.CreateContainsRule(parameter.Id, "some value", false);
                var parameterFilter = new ElementParameterFilter(filterRule);
                var categories = new List<ElementId> { new ElementId(BuiltInCategory.OST_Walls) };

                var filterElement = ParameterFilterElement.Create(doc, "Filter", categories, parameterFilter);
                view.SetFilterVisibility(filterElement.Id, false);

                t.Commit();
            }

            var fec = new FilteredElementCollector(doc)
                    .OfClass(typeof(Wall))
                    .Where(x => x.get_Parameter(new Guid())?.AsDouble() > 5)
                    //.Where(x => x.LookupParameter("Unconnected Height")?.AsDouble() > 5)
                    .ToList();


            //var parameter = fec.Select(x => x.get_Parameter(BuiltInParameter.WALL_USER_HEIGHT_PARAM)).ToList();

            return Result.Succeeded;
        }
    }
}
