using System.Configuration;

namespace StackOverflowTagFetcher.Business.Configurations
{
    public static class SiteSettings
    {
        public static readonly string StackExchangeApiRoot = ConfigurationManager.AppSettings["StackExchangeApiRoot"];
    }
}