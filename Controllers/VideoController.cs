using Microsoft.AspNetCore.Mvc;
using StreamApp.Models;

namespace StreamApp.Controllers
{
    public class VideoController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public VideoController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        static readonly List<Video> videos = [];

        public IActionResult Index()
        {
            return View(videos);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Store(Video video)
        {
            videos.Add(video);
            return RedirectToAction("Index");
        }

        public IActionResult Show(int id)
        {
            var video = videos.Find(v => v.Id == id);
            return View(video);
        }

        public IActionResult Edit(int id)
        {
            var video = videos.Find(v => v.Id == id);
            return View(video);
        }

        [HttpPost]
        public IActionResult Update(Video video)
        {
            var index = videos.FindIndex(v => v.Id == video.Id);
            videos[index] = video;
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var video = videos.Find(v => v.Id == id);
            return View(video);
        }

        [HttpPost]
        public IActionResult Destroy(int id)
        {

            var video = videos.Find(v => v.Id == id);
            if (video != null)
            {
                videos.Remove(video);
            }

            return RedirectToAction("Index");
        }
    }
}