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

        [JsonIgnore]
        public string CreatedAt { get; set; }

        [JsonIgnore]
        public string UpdatedAt { get; set; }

        [JsonProperty(PropertyName = "Topic Areas")]
        public int NumTopics { get; set; }

        [JsonProperty(PropertyName = "impacts")] 
        public int NumImpacts { get; set; }

        [JsonProperty(PropertyName = "City")]
        public string City { get; set; }

        [JsonProperty(PropertyName = "Country")]
        public string Country { get; set; }

        [JsonProperty(PropertyName = "Latitude")]
        public float Latitude { get; set; }

        [JsonProperty(PropertyName = "Longitude")]
        public float Longitude { get; set; }

        [JsonProperty(PropertyName = "General Info")]
        public string Desc { get; set; }

        [JsonProperty(PropertyName = "nc_prk2___nc_m2m_mlucus5b5ds")] 
        public List<TableMap> TableMapList { get; set; }
    }

    public class Topic
    {
        [JsonProperty(PropertyName = "Id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "Title")]
        public string Title { get; set; }

        [JsonIgnore]
        public string CreatedAt { get; set; }

        [JsonIgnore]
        public string UpdatedAt { get; set; }

        [JsonProperty(PropertyName = "un-offices")]
        public int NumOffices { get; set; }

        [JsonProperty(PropertyName = "impacts")]
        public int NumImpacts { get; set; }

        [JsonProperty(PropertyName = "nc_prk2___nc_m2m_mlucus5b5ds")]
        public List<TableMap> TableMapList { get; set; }
    }

    public class TableMap
    {
        [JsonProperty(PropertyName = "table2_id")]
        public int Table2ID { get; set; }

        [JsonProperty(PropertyName = "table1_id")]
        public int Table1ID { get; set; }
    }

    public class Impact
    {
        [JsonProperty(PropertyName = "Id")]
        public int Id{ get; set; }

        [JsonProperty(PropertyName = "Title")]
        public string Title { get; set; }

        [JsonIgnore]
        public string CreatedAt { get; set; }

        [JsonIgnore]
        public string UpdatedAt { get; set; }

        [JsonProperty(PropertyName = "Description")]
        public string Desc { get; set; }

        [JsonProperty(PropertyName = "Year")]
        public int Year { get; set; }

        [JsonProperty(PropertyName = "nc_prk2___topic-areas_id")]
        public int TopicId { get; set; }

        [JsonProperty(PropertyName = "nc_prk2___un-offices_id")]
        public int OfficeId { get; set; }

        [JsonProperty(PropertyName = "Latitude")]
        public float Latitude { get; set; }

        [JsonProperty(PropertyName = "Longitude")]
        public float Longitude { get; set; }

        [JsonProperty(PropertyName = "City")]
        public string City { get; set; }

        [JsonProperty(PropertyName = "Country")]
        public string Country { get; set; }

        [JsonProperty(PropertyName = "sdgs")] 
        public int NumSDGs { get; set; }

        [JsonProperty(PropertyName = "nc_prk2___nc_m2m_qpbzx054jus")]
        public List<TableMap> TableMapList { get; set; }

        [JsonProperty(PropertyName = "topic-areas")]
        public Topic Topic { get; set; }

        [JsonProperty(PropertyName = "un-offices")]
        public Office Office { get; set; }

    }

    public class ImpactList
    {
        [JsonProperty(PropertyName = "list")]
        public List<Impact> AllImpacts { get; set; }
    }
}
