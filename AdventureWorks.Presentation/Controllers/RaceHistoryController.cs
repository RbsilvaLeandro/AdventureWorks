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
    public class RaceHistoryController : Controller
    {
        const string BaseUrl = "https://localhost:44311/";
                
        public IActionResult Index()
        {
            IEnumerable<RaceHistoryViewModel> raceHistory = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);

                var responseTask = client.GetAsync("RaceHistory");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<RaceHistoryViewModel>>();
                    readTask.Wait();

                    raceHistory = readTask.Result;
                }
                else
                {
                    raceHistory = Enumerable.Empty<RaceHistoryViewModel>();
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(raceHistory);
        }

        public ActionResult Details(int id)
        {
            return View();
        }


        public ActionResult create()
        {
            IEnumerable<CompetitorViewModel> competitors = null;
            IEnumerable<RaceTrackViewModel> raceTracks = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);

                var responseTask = client.GetAsync("Competitor");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<CompetitorViewModel>>();
                    readTask.Wait();

                    competitors = readTask.Result;
                }

                responseTask = client.GetAsync("RaceTrack");
                responseTask.Wait();

                result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<RaceTrackViewModel>>();
                    readTask.Wait();

                    raceTracks = readTask.Result;
                }
            }
            
            ViewData["Competitors"] = competitors;
            ViewData["RaceTrack"] = raceTracks;

            return View();
        }
        [HttpPost]
        public ActionResult create(RaceHistoryViewModel raceHistory)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);

                var postTask = client.PostAsJsonAsync<RaceHistoryViewModel>("RaceHistory", raceHistory);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                    return RedirectToAction("Index");
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View(raceHistory);
        }

        public ActionResult Edit(int id)
        {
            RaceHistoryViewModel raceHistory = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                var responseTask = client.GetAsync("RaceHistory/" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<RaceHistoryViewModel>();
                    readTask.Wait();

                    raceHistory = readTask.Result;
                }
            }
            return View(raceHistory);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RaceHistoryViewModel raceHistory)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(BaseUrl);

                   
                    var putTask = client.PutAsJsonAsync<RaceHistoryViewModel>("RaceHistory/" + id.ToString(), raceHistory);
                    putTask.Wait();

                    var result = putTask.Result;

                    if (result.IsSuccessStatusCode)
                        return RedirectToAction("Index");
                }
                return View(raceHistory);
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            RaceHistoryViewModel raceHistory = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                var responseTask = client.GetAsync("RaceHistory/" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<RaceHistoryViewModel>();
                    readTask.Wait();

                    raceHistory = readTask.Result;
                }
            }
            return View(raceHistory);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, RaceHistoryViewModel raceHistory)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);

                var deleteTask = client.DeleteAsync("RaceHistory/" + id.ToString());
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                    return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
    }
}

