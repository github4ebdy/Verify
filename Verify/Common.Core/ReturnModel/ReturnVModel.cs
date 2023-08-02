 
using System.Text.Json.Serialization;
 
namespace Common.Core.ReturnModel
{
    public class ReturnVModel
    {
        public ReturnVModel()
        {

        }
        public string Message { set; get; }

        public Object? Data { set; get; }

        [JsonIgnore]
        public int StatusCode { set; get; }
        public ReturnVModel(string _strMessage, Object? objData = null, int _Code = 200)
        {
            Message = _strMessage;
            Data = objData;
            StatusCode = _Code;
        }
    }
}
