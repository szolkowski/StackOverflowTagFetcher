using StackOverflowTagFetcher.Business;
using StackOverflowTagFetcher.Models;
using System.Web.Mvc;

namespace StackOverflowTagFetcher.Controllers
{
    public class StackOverflowTagsController : Controller
    {
        private readonly ITagsService _tagsService;

        public StackOverflowTagsController(ITagsService tagsService)
        {
            _tagsService = tagsService;
        }

        public ActionResult Index()
        {
            var mostPopularTags = _tagsService.GetMostPopularTags(pageSize: 1000);
            var viewModel = new MostPopularTagPageViewModel(mostPopularTags);

            return View(viewModel);
        }
    }
}