using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiRoutes.App_Code
{
    public class BaseResponse<T>
    {
        /// <summary>
        /// Статус ответы
        /// </summary>
        /// 
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }

        /// <summary>
        /// Данные
        /// </summary>
        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        public T Data { get; set; }
        [JsonProperty("message", NullValueHandling = NullValueHandling.Ignore)]
        public string Message;
    }

    /// <summary>
    /// Статусы
    /// </summary>
    public class StatusCode
    {
        public const string SUCCESS = "OK";
        public const string ERROR = "ERROR";
        public const string NON_HANDLED_ERROR = "NON_HANDLED_ERROR";
    }
}
