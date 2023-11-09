using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DataJson
{
    public class Office
    {
        [JsonProperty(PropertyName = "Id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "Title")]
        public string Title { get; set; }
    }

    public class Topic
    {
        [JsonProperty(PropertyName = "Id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "Title")]
        public string Title { get; set; }
    }

    public class Impact
    {
        [JsonProperty(PropertyName = "Id")]
        public int Id{ get; set; }

        [JsonProperty(PropertyName = "Title")]
        public string Title { get; set; }

        /*        [JsonProperty(PropertyName = "CreatedAt")]
                public string CreatedAt { get; set; }

                [JsonProperty(PropertyName = "UpdatedAt")]
                public string UpdatedAt { get; set; }*/

        [JsonIgnore]
        public string CreatedAt { get; set; }

        [JsonIgnore]
        public string UpdatedAt { get; set; }

        [JsonProperty(PropertyName = "Description")]
        public string Desc { get; set; }

        [JsonProperty(PropertyName = "Location")]
        public string Loc { get; set; }

        [JsonProperty(PropertyName = "Year")]
        public int Year { get; set; }

        [JsonProperty(PropertyName = "nc_prk2___topic-areas_id")]
        public int TopicId { get; set; }

        [JsonProperty(PropertyName = "nc_prk2___un-offices_id")]
        public int OfficeId { get; set; }

        [JsonProperty(PropertyName = "topic-areas")]
        public Topic Topic { get; set; }

        [JsonProperty(PropertyName = "un-offices")]
        public Office Office { get; set; }

    }

    public class Root
    {
        public List<Impact> list { get; set; }
    }
}
