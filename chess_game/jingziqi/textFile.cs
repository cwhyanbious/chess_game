using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jingziqi
{
    class textFile
    {
        //读函数
        public static string Read(string filePath, Encoding encoding)
        {
            using (StreamReader sr = new StreamReader(filePath, encoding))
            {
                return sr.ReadToEnd();
            }
        }
        //写函数
        public static void Write(string filePath, string content, Encoding encoding)
        {
            using (StreamWriter sw = new StreamWriter(filePath, true, encoding))
            {
                sw.Write(content+"\r");
            }
        }
        // 两个静态属性
        public static Encoding UTF8
        {
            get
            {
                return UTF8Encoding.UTF8;
            }
        }
        public static Encoding GBK
        {
            get
            {
                return Encoding.GetEncoding("GBK");
            }
        }
    }
}
