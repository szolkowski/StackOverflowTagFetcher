using Nelibur.ObjectMapper;
using StackOverflowTagFetcher.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Web.Script.Serialization;
using StackOverflowTagFetcher.Business.Configurations;
using StackOverflowTagFetcher.Business.Enums;

namespace StackOverflowTagFetcher.Business
{
    public class StackOverflowApi : IStackOverflowApi
    {
        private const int ApiMaxPageSize = 100;

        public int MaxPageSize => ApiMaxPageSize;

        public IEnumerable<Tag> GetMostPopularTags(int pageSize, int page, SortingOptions sortingOption = SortingOptions.Descending)
        {
            if (pageSize > 0 && pageSize > ApiMaxPageSize)
            {
                throw new ArgumentOutOfRangeException(nameof(pageSize), pageSize, $"pageSize exceeds {nameof(ApiMaxPageSize)} {ApiMaxPageSize}");
            }

            if (page <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(page));
            }

            var apiRoot = SiteSettings.StackExchangeApiRoot;
            if (string.IsNullOrEmpty(apiRoot) || !Uri.IsWellFormedUriString(apiRoot, UriKind.Absolute))
            {
                throw new ConfigurationErrorsException($"{nameof(SiteSettings.StackExchangeApiRoot)} setting is invalid! Value: {apiRoot}");
            }

            var queryPart = $"sort=popular&site=stackoverflow&page={page}&pagesize={pageSize}";
            if (sortingOption == SortingOptions.Descending)
            {
                queryPart += "&order=desc";
            }
            else
            {
                queryPart += "&order=asc";
            }

            var uriBuilder = new UriBuilder(apiRoot)
            {
                Path = "/2.2/tags",
                Query = queryPart
            };

            var result = CallUri<Models.StackOverflowApi.Tags.RootObject>(uriBuilder.Uri);

            return result.items.Select(TinyMapper.Map<Tag>);
        }

        private T CallUri<T>(Uri queryUri) where T : class
        {
            using (var client = new HttpClient())
            {
                var bytes = client.GetByteArrayAsync(queryUri).Result;
                var decompressedJson = new StreamReader(new GZipStream(new MemoryStream(bytes), CompressionMode.Decompress)).ReadToEnd();

                if (string.IsNullOrEmpty(decompressedJson))
                {
                    throw new Exception($"API call have returned empty result: {queryUri}");
                }

                return new JavaScriptSerializer().Deserialize<T>(decompressedJson);
            }
        }
    }
}