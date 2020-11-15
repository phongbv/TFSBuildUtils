using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFSBuildUtils
{
    public class BuildWorkItemInfo
    {
        public string id { get; set; }
        public string url { get; set; }
    }
    public class BuildWorkItemResponse
    {
        public int count { get; set; }
        [JsonProperty("value")]
        public List<BuildWorkItemInfo> RelatedItem { get; set; }


    }
}
