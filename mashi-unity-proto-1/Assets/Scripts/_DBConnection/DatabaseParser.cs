using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DataJson
{
    public class Office
    {
        [JsonProperty(PropertyName = "Id")]
        public int id;

        [JsonProperty(PropertyName = "Title")]
        public string title;
    }

    public class Topic
    {
        [JsonProperty(PropertyName = "Id")]
        public int id;

        [JsonProperty(PropertyName = "Title")]
        public string title;
    }

    public class Impact
    {
        [JsonProperty(PropertyName = "Id")]
        public int id;

        [JsonProperty(PropertyName = "Title")]
        public string title;

        [JsonProperty(PropertyName = "CreatedAt")]
        public string createdAt;

        [JsonProperty(PropertyName = "UpdatedAt")]
        public string updatedAt;

        [JsonProperty(PropertyName = "Description")]
        public string desc;

        [JsonProperty(PropertyName = "Location")]
        public string loc;

        [JsonProperty(PropertyName = "Year")]
        public int year;

        [JsonProperty(PropertyName = "nc_prk2___topic-areas_id")]
        public int topicId;

        [JsonProperty(PropertyName = "nc_prk2___un-offices_id")]
        public int officeId;

        [JsonProperty(PropertyName = "topic-areas")]
        public Topic Topic { get; set; }

        [JsonProperty(PropertyName = "un-offices")]
        public Office Office { get; set; }

    }

    public class ImpactList
    {
        [JsonProperty(PropertyName = "list")]
        public List<Impact> Impacts { get; set; }
    }
}
