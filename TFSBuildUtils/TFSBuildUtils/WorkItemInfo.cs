using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFSBuildUtils
{
    public class WorkItemAttributes
    {

        [JsonProperty("System.AreaPath")]
        public string AreaPath { get; set; }

        [JsonProperty("System.TeamProject")]
        public string TeamProject { get; set; }

        [JsonProperty("System.IterationPath")]
        public string IterationPath { get; set; }

        [JsonProperty("System.WorkItemType")]
        public string WorkItemType { get; set; }

        [JsonProperty("System.State")]
        public string State { get; set; }

        [JsonProperty("System.Reason")]
        public string Reason { get; set; }

        [JsonProperty("System.AssignedTo")]
        public string AssignedTo { get; set; }

        [JsonProperty("System.CreatedDate")]
        public DateTime CreatedDate { get; set; }

        [JsonProperty("System.CreatedBy")]
        public string CreatedBy { get; set; }

        [JsonProperty("System.ChangedDate")]
        public DateTime ChangedDate { get; set; }

        [JsonProperty("System.ChangedBy")]
        public string ChangedBy { get; set; }

        [JsonProperty("System.Title")]
        public string Title { get; set; }

        [JsonProperty("Microsoft.VSTS.Common.Priority")]
        public int Priority { get; set; }

        [JsonProperty("ISTS.AssignedToTester")]
        public string AssignedToTester { get; set; }

        [JsonProperty("ISTS.HandleBy")]
        public string HandleBy { get; set; }

        [JsonProperty("System.Description")]
        public string Description { get; set; }
    }

    public class WorkItemInfo
    {

        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("rev")]
        public int rev { get; set; }
        [JsonProperty("fields")]
        public WorkItemAttributes Fields { get; set; }

        [JsonProperty("url")]
        public string url { get; set; }
    }

}
