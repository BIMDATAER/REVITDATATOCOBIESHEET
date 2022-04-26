using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIMDelivery.Data
{
    class LoginData
    {

        //文件名
        public string acessToken { get; set; }

        //文件扩展名
        public string uID { get; set; }


        public string login{ get; set; }

        public string password { get; set; }

        public string type { get; set; }

        public string verifyCode { get; set; }

        public api_log_data api_log_data { get; set; }

        public string errcode { get; set; }

        public string errmsg { get; set; }

        public string message { get; set; }


        public data data { get; set; }



    }

    public class api_log_data
    {

        public string system_module { get; set; }

        public string operation_type { get; set; }

        public string uid { get; set; }

        public string way_to_request { get; set; }


    }
}
