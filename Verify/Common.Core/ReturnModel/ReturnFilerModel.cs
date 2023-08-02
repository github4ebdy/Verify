using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Common.Core.ReturnModel
{
    public class ReturnFilterModel
    {
        public ReturnFilterModel()
        {

        }
        public int PageSize { set; get; }
        public int PageNum { set; get; }
        public int RecordCount { set; get; }

        public Object? Data { set; get; }

        [JsonIgnore]
        public int StatusCode { set; get; }
        public ReturnFilterModel(int _PageSize = 0, int _PageNum = 0, int _RecordCount = 0, Object? objData = null)
        {

            PageSize = _PageSize;
            PageNum = _PageNum;
            RecordCount = _RecordCount;
            Data = objData;

        }
    }
}
