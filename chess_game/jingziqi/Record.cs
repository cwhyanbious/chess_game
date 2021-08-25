using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace jingziqi
{
    class Record
    {

        public void record(object form)
        {
            string jsonStr = JsonConvert.SerializeObject(form, Formatting.Indented);
            textFile.Write("../record.txt", jsonStr, textFile.UTF8);
        }
    }
}
