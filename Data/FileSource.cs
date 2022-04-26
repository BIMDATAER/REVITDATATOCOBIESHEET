using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIMDelivery.Data
{
    public class FileSource
    {
        //文件类型
        public string fileType { get; set; }

        //文件地址
        public string fileUrl { get; set; }

        //文件名
        public string fileName { get; set; }

        //public data data { get; set; }


        public string errcode { get; set; }

        public string errmsg { get; set; }

        public int count { get; set; }

        public string message { get; set; }

        public List<data> data { get; set; }



    }

    public class data 
    {
        public string res_id { get; set; }

        public string res_model { get; set; }

        public string size { get; set; }

        public string name { get; set; }

        public string url { get; set; }



    }
}
