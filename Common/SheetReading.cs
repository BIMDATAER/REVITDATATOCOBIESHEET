using Autodesk.Revit.DB;
using BIMDelivery.Data;
using BIMDelivery.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIMDelivery.Common
{
    class SheetReading
    {
        //联系人
        public void GetContactFieldValue(Document doc, List<string> fieldnames, bool instanceparam=true)
        {
            string path = FilePathHelper.GetResourcePath() + @"\Resource\update\BIMSpreadsheet.xlsx";





        }

        //设施
        public Dictionary<string, string> GetFacilityFieldValue(Document doc, string fieldname)
        {
            string path = FilePathHelper.GetResourcePath() + @"\Resource\update\BIMSpreadsheet.xlsx";

            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
            ExcelOperation excelOperation = new ExcelOperation();

            //通过名称后期查找元素，可改成GUID
            KeyValuePair<string, string> keyValuePair = new KeyValuePair<string, string>("设施名称", fieldname);

            //读取excel
            keyValuePairs = excelOperation.ReadBook(path, 2, keyValuePair);
            return keyValuePairs;


        }

        //楼层
        public Dictionary<string,string> GetFloorFieldValue(Document doc, string fieldname)
        {
            string path = FilePathHelper.GetResourcePath() + @"\Resource\update\BIMSpreadsheet.xlsx";

            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
            ExcelOperation excelOperation = new ExcelOperation();

            //通过名称后期查找元素，可改成GUID
            KeyValuePair<string, string> keyValuePair = new KeyValuePair<string, string>("名称", fieldname);

            //读取excel
            keyValuePairs = excelOperation.ReadBook(path, 3, keyValuePair);
            return keyValuePairs;

        }


        //房间表
        public void GetSpaceFieldValue(Document doc, List<string> fieldnames, bool instanceparam=true)
        {
            string path = FilePathHelper.GetResourcePath() + @"\Resource\update\BIMSpreadsheet.xlsx";





        }

        //类型表
        public Dictionary<string,string> GetTypeFieldValue(Document doc, string fieldname)
        {
            string path = FilePathHelper.GetResourcePath() + @"\Resource\update\BIMSpreadsheet.xlsx";

            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
            ExcelOperation excelOperation = new ExcelOperation();

            //通过名称后期查找元素，可改成GUID
            KeyValuePair<string, string> keyValuePair = new KeyValuePair<string, string>("名称", fieldname);
            
            //读取excel
            keyValuePairs=excelOperation.ReadBook(path, 6, keyValuePair);




            return keyValuePairs;
        }


        //组件表
        public Dictionary<string,string> GetComponentFieldValue(Document doc, string fieldname)
        {
            string path = FilePathHelper.GetResourcePath() + @"\Resource\update\BIMSpreadsheet.xlsx";

            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
            ExcelOperation excelOperation = new ExcelOperation();

            //通过名称后期查找元素，可改成GUID
            KeyValuePair<string, string> keyValuePair = new KeyValuePair<string, string>("名称", fieldname);

            //读取excel
            keyValuePairs = excelOperation.ReadBook(path, 7, keyValuePair);

            return keyValuePairs;


        }




    }




}
