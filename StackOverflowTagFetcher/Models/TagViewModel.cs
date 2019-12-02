namespace StackOverflowTagFetcher.Models
{
    public class TagViewModel
    {
        public string Name { get; }
        public int Count { get; }
        public double TagPopularityInFetchedData { get; }

        public TagViewModel(string name, int count, double tagPopularityInFetchedData)
        {
            Name = name;
            Count = count;
            TagPopularityInFetchedData = tagPopularityInFetchedData;
        }
    }
}