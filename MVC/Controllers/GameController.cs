using ApplicationService.DTOs;
using MVC.ViewModels;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class GameController : Controller
    {
        public ActionResult Index()
        {
            List<GameViewModel> gameVM = new List<GameViewModel>();
            using (GameService.GameClient service = new GameService.GameClient())
            {
                foreach (var item in service.GetGames())
                {
                    gameVM.Add(new GameViewModel(item));
                }
            }
            return View(gameVM);


        }

        public ActionResult Details(int id)
        {
            GameViewModel gameVM = new GameViewModel();
            using (GameService.GameClient service = new GameService.GameClient())
            {
                var gameDto = service.GetGameByID(id);
                gameVM = new GameViewModel(gameDto);
            }

            return View(gameVM);
        }

        // GET: Nationality/Edit/5
        public ActionResult Edit(int id)
        {
            GameViewModel gameVM = new GameViewModel();
            using (GameService.GameClient service = new GameService.GameClient())
            {
                var nationalityDto = service.GetGameByID(id);
                gameVM = new GameViewModel(nationalityDto);
            }


            return View(gameVM);
        }

        // POST: Nationality/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(GameViewModel gameVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (GameService.GameClient service = new GameService.GameClient())
                    {
                        GameDTO gameDto = new GameDTO
                        {
                            Id = gameVM.Id,
                            Title = gameVM.Title,
                            Details = gameVM.Details,
                            ReleaseDate = gameVM.ReleaseDate,
                            Size = gameVM.Size,
                            Platform = gameVM.Platform,
                            Publisher = gameVM.Publisher
                    };
                        service.PostGame(gameDto);
                    }

                    return RedirectToAction("Index");
                }

                return View();
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Delete(int id)
        {
            GameViewModel gameVM = new GameViewModel();

            using (GameService.GameClient service = new GameService.GameClient())
            {
                service.DeleteGame(id);
            }
            return RedirectToAction("Index");
        }


        public ActionResult Create()
        {

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GameViewModel gameVM)
        {
            try
            {

                var gameURL = "https://www.freetogame.com/api/game?id=";

                var client = new WebClient();
                var body = "";
                var value = "";
                var desc = "";
                var genre = "";
                var rdate = "";
                var size = "";
                var publisher = "";
                var platform = "";

                    body = client.DownloadString(gameURL + gameVM.Title);

                    JObject data = JObject.Parse(body);

                    value = (string)data["title"];
                    desc = (string)data["short_description"];
                    genre = (string)data["genre"];
                    rdate = (string)data["release_date"];
                if ((string)data["minimum_system_requirements"]["storage"] == null)
                {
                    size = "Unspecified";
                }
                else
                {
                    size = (string)data["minimum_system_requirements"]["storage"];
                }
                    publisher = (string)data["publisher"];
                    platform = (string)data["platform"];


                using (GameService.GameClient service = new GameService.GameClient())
                {
                    GameDTO gameDto = new GameDTO
                    {

                        Title = value ,
                        Details = desc,
                        Genre = genre,
                        ReleaseDate = rdate,
                        Size = size,
                        Platform = platform,
                        Publisher = publisher
                    };
                    service.PostGame(gameDto);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}