using StackOverflowTagFetcher.Models;
using System.Collections.Generic;

namespace StackOverflowTagFetcher.Business
{
    public class TagsService : ITagsService
    {
        private readonly IStackOverflowApi _stackOverflowApi;

        public TagsService(IStackOverflowApi stackOverflowApi)
        {
            _stackOverflowApi = stackOverflowApi;
        }

        public List<Tag> GetMostPopularTags(int pageSize)
        {
            var mostPopularTags = new List<Tag>();
            var runs = pageSize / _stackOverflowApi.MaxPageSize;
            var callPageSize = pageSize > _stackOverflowApi.MaxPageSize ? _stackOverflowApi.MaxPageSize : pageSize;
            for (var i = 1; i <= runs; i++)
            {
                mostPopularTags.AddRange(_stackOverflowApi.GetMostPopularTags(callPageSize, page: i));
            }

            return mostPopularTags;
        }
    }
}