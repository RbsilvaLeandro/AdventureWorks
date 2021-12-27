using AdventureWorks.Presentation.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AdventureWorks.Presentation.Controllers
{

    public class RaceTrackController : Controller
    {
        const string BaseUrl = "https://localhost:44311/";

        public IActionResult Index()
        {            
            IEnumerable<RaceTrackViewModel> raceTrack = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);

                var responseTask = client.GetAsync("RaceTrack");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<RaceTrackViewModel>>();
                    readTask.Wait();

                    raceTrack = readTask.Result;
                }
                else
                {
                    raceTrack = Enumerable.Empty<RaceTrackViewModel>();
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(raceTrack);
        }

        public IActionResult ListUnusedTracks()
        {
            IEnumerable<RaceTrackViewModel> raceTrack = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);

                var responseTask = client.GetAsync("RaceTrack");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<RaceTrackViewModel>>();
                    readTask.Wait();

                    raceTrack = readTask.Result.Where(x => x.IsUsed == false);
                }
                else
                {
                    raceTrack = Enumerable.Empty<RaceTrackViewModel>();
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(raceTrack);
        }


        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RaceTrackViewModel raceTrack)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);

                var postTask = client.PostAsJsonAsync<RaceTrackViewModel>("RaceTrack", raceTrack);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                    return RedirectToAction("Index");
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View(raceTrack);
        }

        public ActionResult Edit(int id)
        {
            RaceTrackViewModel raceTrack = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                var responseTask = client.GetAsync("RaceTrack/" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<RaceTrackViewModel>();
                    readTask.Wait();

                    raceTrack = readTask.Result;
                }
            }
            return View(raceTrack);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RaceTrackViewModel raceTrack)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(BaseUrl);
                    var putTask = client.PutAsJsonAsync<RaceTrackViewModel>("RaceTrack/" + id.ToString(), raceTrack);
                    putTask.Wait();

                    var result = putTask.Result;

                    if (result.IsSuccessStatusCode)
                        return RedirectToAction("Index");
                }
                return View(raceTrack);
            }
            catch
            {
                return View();
            }

        }

        public ActionResult Delete(int id)
        {
            RaceTrackViewModel raceTrack = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                var responseTask = client.GetAsync("RaceTrack/" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<RaceTrackViewModel>();
                    readTask.Wait();

                    raceTrack = readTask.Result;
                }
            }
            return View(raceTrack);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, RaceTrackViewModel raceTrack)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);

                var deleteTask = client.DeleteAsync("RaceTrack/" + id.ToString());
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                    return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
    }
}
