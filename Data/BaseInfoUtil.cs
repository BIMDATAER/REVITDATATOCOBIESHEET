using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIMDelivery.Data
{
    class BaseInfoUtil
    {

        //登录接口
        public static string LoginUrl() { return "http://192.168.32.46:8069/api/v1/login/0"; }

        //上传接口
        public static string UploadUrl() { return "http://192.168.32.46:8069/web/revit/upload/file"; }

        //下载接口
        public static string DownloadUrl() { return "http://192.168.32.46:8069/web/revit/download/file/page"; }


    }
}
