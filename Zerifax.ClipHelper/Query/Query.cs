using Newtonsoft.Json;

namespace Zerifax.ClipHelper.Query
{
    /*
    public class Operation
    {
        [JsonProperty("operationName")]
        public string OperationName { get; set; }
        
        [JsonProperty("variables")]
        public OperationVariables Variables { get; set; }
    }

    public class OperationVariables
    {
        [JsonProperty("slug")]
        public string Slug { get; set; }
    }*/

    public class Query
    {
        [JsonProperty("query")]
        public string QueryGraph { get; set; }
    }
}