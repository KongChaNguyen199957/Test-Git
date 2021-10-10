using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Angular.Model.Models
{
    public class ResponseModel
    {
        public string Message { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public int StatusCode { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public object Data { get; set; }
       
    }
}
