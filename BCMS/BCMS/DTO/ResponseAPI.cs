using Newtonsoft.Json;

namespace BCMS.DTO
{
    public class ResponseAPI<T>
    {
        public string Message { get; set; }

        public bool _isIgnoreNullData;
        private object _data;
        public object Data
        {
            get; set;
            /* get
             {
                 if (this._isIgnoreNullData)
                     return JsonConvert.SerializeObject(_data, _jsonSerializerSettings);
                 else
                     return JsonConvert.SerializeObject(_data);
             }
             set
             {
                 _data = value;
             }*/
        }

        private static JsonSerializerSettings _jsonSerializerSettings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            MissingMemberHandling = MissingMemberHandling.Ignore
        };

        public ResponseAPI(bool isIgnoreNullData = true)
        {
            this._isIgnoreNullData = isIgnoreNullData;
        }
    }
}
