using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StackOverflowAnswers.Revit
{
    internal class Application : IExternalApplication
    {
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            var assemblyPath = Assembly.GetExecutingAssembly().Location;
            var buttonData = new PushButtonData("buttonName", "buttonText", assemblyPath, typeof(MyCommand).FullName);
            buttonData.AvailabilityClassName = typeof(ProjectOnlyAvailability).FullName;

            // Create a custom ribbon tab
            var tabName = "Dev";
            var panelName = "Dev";
            application.CreateRibbonTab(tabName);


            // Create a ribbon panel
            var panel = application.CreateRibbonPanel(tabName, panelName);
            panel.AddItem(buttonData);

            return Result.Succeeded;
        }
    }

    public class MyCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            TaskDialog.Show("Test", "Test");
            return Result.Succeeded;
        }
    }

    public class ProjectOnlyAvailability : IExternalCommandAvailability
    {
        public bool IsCommandAvailable(UIApplication applicationData, CategorySet selectedCategories)
        {
            if (applicationData?.ActiveUIDocument?.Document == null) 
                return false; // not available with no document open

            if (applicationData.ActiveUIDocument.Document.IsFamilyDocument) 
                return false; // not available for family documents
            
            return true;
        }
    }
}
