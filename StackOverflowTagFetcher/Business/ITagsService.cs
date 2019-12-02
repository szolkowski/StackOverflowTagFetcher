using StackOverflowTagFetcher.Models;
using System.Collections.Generic;

namespace StackOverflowTagFetcher.Business
{
    public interface ITagsService
    {
        List<Tag> GetMostPopularTags(int pageSize);
    }
}