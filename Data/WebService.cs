using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace BIMDelivery.Data
{
    class WebService
    {

        public static string WebLogin(string url)
        {

            try
            {

                HttpClient httpClient = new HttpClient();
                LoginData loginData = new LoginData();

                string postdata = "login=admin&password=admin&type=0";
                byte[] data = Encoding.UTF8.GetBytes(postdata);
                HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(url + postdata);
                webrequest.Method = "POST";
                webrequest.ContentType = "application/x-www-form-urlencoded";
                webrequest.ContentLength = data.Length;
                Stream stream = webrequest.GetRequestStream();
                stream.Write(data, 0, data.Length);
                stream.Close();
                HttpWebResponse webresponse = (HttpWebResponse)webrequest.GetResponse();
                StreamReader sr = new StreamReader(webresponse.GetResponseStream(), Encoding.UTF8);
                string s = sr.ReadToEnd();

                return s;

            }
            catch (Exception e)
            {
                //添加日志 log4net插件
                return null;
            }
        }



        /// <summary>
        /// 文件下载
        /// </summary>
        /// <param name="url"></param>
        /// <param name="LocalFileName"></param>
        public static void DownloadFile(string url,string LocalFileName)
        {
            try
            {

                string dir = Path.GetDirectoryName(LocalFileName);
                DirectoryInfo directoryInfo = new DirectoryInfo(dir);
                if (!directoryInfo.Exists)
                {
                    directoryInfo.Create();
                }
                HttpClient httpClient = new HttpClient();

                HttpResponseMessage httpResponseMessage = httpClient.GetAsync(url).GetAwaiter().GetResult();
                byte[] buffer = new byte[2048];
                using (var body=httpResponseMessage.Content.ReadAsStreamAsync().GetAwaiter().GetResult()) 
                {
                    var len = 0;
                    using (FileStream fs=new FileStream(LocalFileName,FileMode.OpenOrCreate,FileAccess.ReadWrite))
                    {
                        while ((len=body.Read(buffer,0,2048))>0)
                        {
                            fs.Write(buffer,0,len);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                //添加日志 log4net插件

            }

        }


        /// <summary>
        /// 文件上传
        /// </summary>
        /// <param name="strUrl"></param>
        /// <param name="fileFullName"></param>
        /// <param name="strFileName"></param>
        /// <param name="requestToken"></param>
        /// <returns></returns>
        public static HttpResponseMessage UpLoadFile(string strUrl, List<UploadFileInfo> uploadFileInfos, string modeLName)
        {


            //string loginUrl = "http://192.168.32.46:8069/api/v1/login/0";
            //String s = WebLogin(loginUrl);

            //LoginData loginData = JsonConvert.DeserializeObject<LoginData>(s);

            //string acesstoken = loginData.data.access_token;
            //string uid = loginData.data.uid;



            HttpClient client = new HttpClient();

            data data = new data();
            data.res_id = "34";
            data.res_model = "xiexiang";
            data.size = "3024";

            string p = JsonConvert.SerializeObject(data,new JsonSerializerSettings {NullValueHandling=NullValueHandling.Ignore });

            MultipartContent multipartContent = new MultipartContent();



            MultipartFormDataContent formdata = new MultipartFormDataContent();
            //FormUrlEncodedContent formUrlEncodedContent = new FormUrlEncodedContent(directories);

            //ByteArrayContent fileContent = new ByteArrayContent(File.ReadAllBytes(fileFullName));

            //HttpContent httpContent = new StringContent(formUrlEncodedContent.ToString());

            formdata.Add(new StringContent("ir.attachment"), "model");
            formdata.Add(new StringContent("ir_upload"), "upload_type");
            //formdata.Add(new StringContent(acesstoken), "access_token");
            formdata.Add(new StringContent("2"), "uid");
            formdata.Add(new StringContent(p), "data");


            foreach (UploadFileInfo item in uploadFileInfos)
            {
                string fileFullName = item.localfileName;
                ByteArrayContent fileContent = new ByteArrayContent(File.ReadAllBytes(fileFullName));
                string strfilename = string.Format("{0}{1}", item.filename, item.fileExt);
                multipartContent.Add(fileContent);
            }

            formdata.Add(multipartContent, "files");

            //string strfilename = string.Format("{0}{1}", uploadFileInfos[0].filename, uploadFileInfos[0].fileExt);
            //string fileFullName = uploadFileInfos[0].localfileName;
            //ByteArrayContent fileContent = new ByteArrayContent(File.ReadAllBytes(fileFullName));
            //formdata.Add(fileContent, "files", strfilename);


            return client.PostAsync(strUrl, formdata).GetAwaiter().GetResult();

        }



        /// <summary>
        /// HttpUploadFile
        /// </summary>
        /// <param name="url"></param>
        /// <param name="files"></param>
        /// <param name="data"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string HttpUploadFile(string url, string[] files, Dictionary<string, string> data, Encoding encoding)
        {
            //必须
            string boundary = DateTime.Now.Ticks.ToString("X");
            //必须的

            //form 开始标志
            byte[] boundarybytes = Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");

            //form 结尾标志
            byte[] endbytes = Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");

            //1.HttpWebRequest
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            request.ContentType = "multipart/form-data;charset=utf-8;boundary=" + boundary;
            request.Method = "POST";
            request.KeepAlive = true;
            request.Credentials = CredentialCache.DefaultCredentials;

            using (Stream stream = request.GetRequestStream())
            {
                //传递参数模板 Content-Disposition:form-data;name=\"{0}\"\r\n\r\n{1}
                //1.1 key/value
                string formdataTemplate = "Content-Disposition:form-data;name=\"{0}\"\r\n\r\n{1}";
                //传递参数
                if (data != null)
                {
                    foreach (string key in data.Keys)
                    {
                        //传递参数开始标识
                        stream.Write(boundarybytes, 0, boundarybytes.Length);

                        string formitem = string.Format(formdataTemplate, key, data[key]);

                        byte[] formitembytes = encoding.GetBytes(formitem);

                        stream.Write(formitembytes, 0, formitembytes.Length);
                    }
                }

                //上传文件模板
                //1.2 file
                string headerTemplate = "Content-Disposition:form-data;name=\"{0}\";filename=\"{1}\"\r\nContent-Type:application/octet-stream\r\n\r\n";

                byte[] buffer = new byte[6 * 1024 * 1024];

                for (int i = 0; i < files.Length; i++)
                {
                    //上传文件标识
                    stream.Write(boundarybytes, 0, boundarybytes.Length);

                    //string header = string.Format(headerTemplate, "file" + i, Path.GetFileName(files[i]));

                    string header = string.Format(headerTemplate, "files" + i, Path.GetFileName(files[i]));

                    byte[] headerbytes = encoding.GetBytes(header);

                    stream.Write(headerbytes, 0, headerbytes.Length);

                    //将文件流读入到请求流中
                    using (FileStream fileStream = new FileStream(files[i], FileMode.Open, FileAccess.Read))
                    {
                        int r = fileStream.Read(buffer, 0, buffer.Length);
                        stream.Write(buffer, 0, r);
                    }
                }
                
                //form 结束标志
                //1.3 form end
                stream.Write(endbytes, 0, endbytes.Length);
            }
            //2.WebResponse
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (StreamReader stream = new StreamReader(response.GetResponseStream()))
            {

                string result = stream.ReadToEnd();
                return result;
            }
        }




    }
}
