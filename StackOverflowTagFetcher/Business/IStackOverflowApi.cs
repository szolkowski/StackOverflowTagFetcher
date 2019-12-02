using System.Collections.Generic;
using StackOverflowTagFetcher.Business.Enums;
using StackOverflowTagFetcher.Models;

namespace StackOverflowTagFetcher.Business
{
    public interface IStackOverflowApi
    {
        int MaxPageSize { get; }
        IEnumerable<Tag> GetMostPopularTags(int pageSize, int page, SortingOptions sortingOption = SortingOptions.Descending);
    }
}