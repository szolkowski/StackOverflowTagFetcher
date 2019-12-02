using System.Collections.Generic;

namespace StackOverflowTagFetcher.Models.StackOverflowApi.Tags
{
    /// <summary>
    /// Parent used for serialization of StackOverflowApi tags response.
    /// </summary>
    public class RootObject
    {
        public List<Item> items { get; set; }
        public bool has_more { get; set; }
        public int quota_max { get; set; }
        public int quota_remaining { get; set; }
    }
}