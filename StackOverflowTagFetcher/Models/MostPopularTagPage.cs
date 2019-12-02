using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace StackOverflowTagFetcher.Models
{
    public class MostPopularTagPageViewModel
    {
        public ReadOnlyCollection<TagViewModel> Tags { get; }

        public MostPopularTagPageViewModel(IEnumerable<Tag> mostPopularTags)
        {
            var tagsViewModels = new List<TagViewModel>();
            var popularTags = mostPopularTags.ToList();
            var totalCount = popularTags.Sum(tag => tag.Count);
            foreach(var tag in popularTags)
            {
                var tagPopularityInFetchedData = tag.Count / (double)totalCount;
                tagsViewModels.Add(new TagViewModel(tag.Name, tag.Count, tagPopularityInFetchedData));
            }

            Tags = tagsViewModels.AsReadOnly();
        }
    }
}