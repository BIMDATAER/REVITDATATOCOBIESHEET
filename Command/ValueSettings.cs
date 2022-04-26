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
    class ValueSettings : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Document doc = commandData.Application.ActiveUIDocument.Document;
            SettingsForm settingform = new SettingsForm(doc);
            RevitParamSetting revitParamSetting = new RevitParamSetting();
            if (settingform.ShowDialog()==DialogResult.OK )
            {
                ////后改为动态路径
                //string path = @"E:\program\BIMDelivery\BIMDelivery\Resource\BIMSpreadsheet.xlsx";
                Transaction trans = new Transaction(doc,"设置属性值");
                trans.Start();
                revitParamSetting.SetRevitFacilityParamValue(doc, settingform);
                revitParamSetting.SetRevitComponentParamValue(doc, settingform);
                revitParamSetting.SetRevitFloorParamValue(doc, settingform);
                revitParamSetting.SetRevitSystemParamValue(doc, settingform);
                revitParamSetting.SetRevitTypeParamValue(doc, settingform);
                revitParamSetting.SetRevitSpaceParamValue(doc, settingform);
                revitParamSetting.SetRevitContactParamValue(doc, settingform);
                trans.Commit();


            }
             
            return Result.Succeeded ;
        }
    }
}
