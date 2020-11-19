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
        [JsonProperty("_links")]
        public Links Links { get; set; }
    }
    public class Self
    {

        [JsonProperty("href")]
        public string Href { get; set; }
    }

    public class WorkItemUpdates
    {

        [JsonProperty("href")]
        public string Href { get; set; }
    }

    public class WorkItemRevisions
    {

        [JsonProperty("href")]
        public string Href { get; set; }
    }

    public class WorkItemHistory
    {

        [JsonProperty("href")]
        public string Href { get; set; }
    }

    public class Html
    {

        [JsonProperty("href")]
        public string Href { get; set; }
    }

    public class WorkItemType
    {

        [JsonProperty("href")]
        public string Href { get; set; }
    }

    public class Links
    {

        [JsonProperty("self")]
        public Self Self { get; set; }

        [JsonProperty("workItemUpdates")]
        public WorkItemUpdates WorkItemUpdates { get; set; }

        [JsonProperty("workItemRevisions")]
        public WorkItemRevisions WorkItemRevisions { get; set; }

        [JsonProperty("workItemHistory")]
        public WorkItemHistory WorkItemHistory { get; set; }

        [JsonProperty("html")]
        public Html Html { get; set; }

        [JsonProperty("workItemType")]
        public WorkItemType WorkItemType { get; set; }

    }

}
