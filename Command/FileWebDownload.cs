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
    class FileWebDownload : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {

            //string loginUrl = "http://192.168.32.46:8069/api/v1/login/0";
            //string s = WebService.WebLogin(loginUrl);

            //LoginData loginData = JsonConvert.DeserializeObject<LoginData>(s);

            //string acesstoken = loginData.data.access_token;
            //string uid = loginData.data.uid;



            //List<FileSource> fileSources = null;
            string url = BaseInfoUtil.DownloadUrl();
            string path = FilePathHelper.GetResourcePath() + @"\Resource\"; 
            HttpClient httpClient = new HttpClient();

            MultipartFormDataContent formdata = new MultipartFormDataContent();


            formdata.Add(new StringContent("ir.attachment"), "model");
            //formdata.Add(new StringContent(acesstoken), "access_token");
            //formdata.Add(new StringContent(uid), "uid");
            formdata.Add(new StringContent("xiexiang"), "res_model");
            formdata.Add(new StringContent("34"), "res_id");
            formdata.Add(new StringContent("api_get_page"), "function_name");



            HttpResponseMessage httpResponseMessage = httpClient.PostAsync(url, formdata).GetAwaiter().GetResult();


            string ss = httpResponseMessage.Content.ReadAsStringAsync().Result;
            //MessageBox.Show(ss,"111");

            FileSource fileSource =JsonConvert.DeserializeObject<FileSource>(httpResponseMessage.Content.ReadAsStringAsync().Result);

            List<data> datas=fileSource.data;

            foreach (data data in datas)
            {
                string loca1filename = string.Format("{0}{1}", path, data.name);

                WebService.DownloadFile(data.url, loca1filename);
            }

            MessageBox.Show("下载成功","提示");

            return Result.Succeeded ;
        }

    }
}
