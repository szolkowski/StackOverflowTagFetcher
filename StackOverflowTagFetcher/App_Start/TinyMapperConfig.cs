using Nelibur.ObjectMapper;
using StackOverflowTagFetcher.Models;

namespace StackOverflowTagFetcher
{
    public static class TinyMapperConfig
    {
        public static void RegisterBindings()
        {
            TagBinding();
        }

        private static void TagBinding()
        {
            TinyMapper.Bind<Models.StackOverflowApi.Tags.Item, Tag>(config =>
            {
                config.Bind(source => source.count, target => target.Count);
                config.Bind(source => source.has_synonyms, target => target.HasSynonyms);
                config.Bind(source => source.is_moderator_only, target => target.IsModeratorOnly);
                config.Bind(source => source.is_required, target => target.IsRequired);
                config.Bind(source => source.name, target => target.Name);
            });
        }
    }
}