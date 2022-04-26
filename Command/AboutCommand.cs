using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using BIMDelivery.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BIMDelivery.Common;
using BIMDelivery.Data;

namespace BIMDelivery.Command
{
    [Transaction(TransactionMode.Manual)]
    class AboutCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {


            AboutForm aboutconform = new AboutForm();
            aboutconform.ShowDialog();
             
            return Result.Succeeded ;
        }
    }
}
