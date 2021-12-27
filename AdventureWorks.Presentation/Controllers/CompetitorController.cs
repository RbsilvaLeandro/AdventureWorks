using AdventureWorks.Presentation.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;

namespace AdventureWorks.Presentation.Controllers
{
    public class CompetitorController : Controller
    {
        const string BaseUrl = "https://localhost:44311/";

        public IActionResult Index()
        {
            IEnumerable<CompetitorViewModel> competitors = null;

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
                else
                {
                    competitors = Enumerable.Empty<CompetitorViewModel>();
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(competitors);
        }
        public IActionResult ListNoRunner()
        {
            IEnumerable<CompetitorViewModel> competitors = null;

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

                    competitors = readTask.Result.Where(x => x.IsRunner == false);
                }
                else
                {
                    competitors = Enumerable.Empty<CompetitorViewModel>();
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(competitors);
        }


        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult create(CompetitorViewModel competitor)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                
                var postTask = client.PostAsJsonAsync<CompetitorViewModel>("Competitor", competitor);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                    return RedirectToAction("Index");
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View(competitor);
        }

        public ActionResult Edit(int id)
        {
            CompetitorViewModel competitor = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                var responseTask = client.GetAsync("Competitor/" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<CompetitorViewModel>();
                    readTask.Wait();

                    competitor = readTask.Result;
                }
            }
            return View(competitor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CompetitorViewModel competitor)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(BaseUrl);
                    var putTask = client.PutAsJsonAsync<CompetitorViewModel>("Competitor/" + id.ToString(), competitor);
                    putTask.Wait();

                    var result = putTask.Result;

                    if (result.IsSuccessStatusCode)
                        return RedirectToAction("Index");
                }
                return View(competitor);
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            CompetitorViewModel competitor = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                var responseTask = client.GetAsync("Competitor/" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<CompetitorViewModel>();
                    readTask.Wait();

                    competitor = readTask.Result;
                }
            }
            return View(competitor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);

                var deleteTask = client.DeleteAsync("Competitor/" + id.ToString());
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                    return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
    }
}
