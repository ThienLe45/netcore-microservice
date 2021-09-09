using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Shopping.Client.SD;

namespace Shopping.Client.Models
{
    public class ApiRequest
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string Url { get; set; }
        public object Data { get; set; }
        public string AccessToken { get; set; }
    }
}
