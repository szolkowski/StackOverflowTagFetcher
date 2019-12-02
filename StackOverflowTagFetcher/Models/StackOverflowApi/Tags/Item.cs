namespace StackOverflowTagFetcher.Models.StackOverflowApi.Tags
{
    /// <summary>
    /// Child class used for serialization of StackOverflowApi tags response as part of <see cref="RootObject"/> class.
    /// </summary>
    public class Item
    {
        public bool has_synonyms { get; set; }
        public bool is_moderator_only { get; set; }
        public bool is_required { get; set; }
        public int count { get; set; }
        public string name { get; set; }
    }
}