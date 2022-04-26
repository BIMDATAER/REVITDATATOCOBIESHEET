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
using System.Net.Http;
using Newtonsoft.Json;

namespace BIMDelivery.Command
{
    [Transaction(TransactionMode.Manual)]
    class FileWebUpload : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {

            //List<FileSource> fileSources = null;
            string url = BaseInfoUtil.UploadUrl();
            string path = FilePathHelper.GetResourcePath() + @"\Resource\"; ;

            string modelName = commandData.Application.ActiveUIDocument.Document.PathName;
            List<UploadFileInfo> uploadFileInfos = new List<UploadFileInfo>();


            uploadFileInfos.Add(new UploadFileInfo { filename= "BIMSpreadsheet", fileExt=".xlsx",localfileName=path+ "BIMSpreadsheet"+ ".xlsx" });
            uploadFileInfos.Add(new UploadFileInfo { filename= "Extension Shared Parameters", fileExt = ".txt", localfileName = path + "Extension Shared Parameters" + ".txt" });


            HttpResponseMessage httpResponseMessage = WebService.UpLoadFile(url, uploadFileInfos, modelName);

            string s = httpResponseMessage.Content.ReadAsStringAsync().Result;

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                MessageBox.Show( "上传成功", "提示");
            }




            //foreach (UploadFileInfo UploadFileInfo in uploadFileInfos)
            //{
            //    string strfilename = string.Format("{0}{1}", UploadFileInfo.filename,UploadFileInfo.fileExt);

            //    HttpResponseMessage httpResponseMessage=WebService.UpLoadFile(url, UploadFileInfo.localfileName, strfilename,modelName);

            //    string s = httpResponseMessage.Content.ReadAsStringAsync().Result;


            //    //MessageBox.Show(s,"111");
            //    //if (httpResponseMessage.IsSuccessStatusCode)
            //    //{
            //    //    MessageBox.Show(string.Format("{0}{1}",UploadFileInfo.filename,"上传成功"),"提示");
            //    //}


            //}


            return Result.Succeeded ;
        }
    }
}
