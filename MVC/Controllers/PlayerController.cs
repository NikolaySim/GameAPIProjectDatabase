using ApplicationService.DTOs;
using MVC.Utilities;
using MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class PlayerController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            List<PlayerViewModel> playerVM = new List<PlayerViewModel>();
            using (PlayerService.PlayerClient service = new PlayerService.PlayerClient())
            {
                foreach (var item in service.GetPlayers())
                {
                    playerVM.Add(new PlayerViewModel(item));
                }
            }
            return View(playerVM);

            /*
            return View();
            */
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            PlayerViewModel playerVM = new PlayerViewModel();
            using (PlayerService.PlayerClient service = new PlayerService.PlayerClient())
            {
                var playerDTO = service.GetPlayerByID(id);
                playerVM = new PlayerViewModel(playerDTO);
            }

            return View(playerVM);
        }

        public ActionResult Edit(int id)
        {
            ViewBag.Games = LoadDataUtilities.LoadGamesData();

            PlayerViewModel playerVM = new PlayerViewModel();
            using (PlayerService.PlayerClient service = new PlayerService.PlayerClient())
            {
                var playerDTO = service.GetPlayerByID(id);
                playerVM = new PlayerViewModel(playerDTO);
            }


            return View(playerVM);
        }

        // POST: Nationality/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PlayerViewModel playerVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (PlayerService.PlayerClient service = new PlayerService.PlayerClient())
                    {
                        PlayerDTO playerDTO = new PlayerDTO
                        {
                            Id = playerVM.Id,
                            FirstName = playerVM.FirstName,
                            LastName = playerVM.LastName,
                            DOB = playerVM.DOB,
                            City = playerVM.City,

                        };
                        service.PostPlayer(playerDTO);
                    }

                    return RedirectToAction("Index");
                }
                ViewBag.Games = LoadDataUtilities.LoadGamesData();
                return View();
            }
            catch
            {
                ViewBag.Games = LoadDataUtilities.LoadGamesData();
                return View();
            }
        }

        public ActionResult Delete(int id)
        {

            using (PlayerService.PlayerClient service = new PlayerService.PlayerClient())
            {
                service.DeletePlayer(id);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            ViewBag.Games = LoadDataUtilities.LoadGamesData();

            return View();
        }

        // POST: Nationality/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PlayerViewModel playerVM)
        {
            try
            {
                using (PlayerService.PlayerClient service = new PlayerService.PlayerClient())
                {
                    PlayerDTO playerDto = new PlayerDTO
                    {
                        FirstName = playerVM.FirstName,
                        LastName = playerVM.LastName,
                        City = playerVM.City,
                        DOB = playerVM.DOB,
                    };
                    service.PostPlayer(playerDto);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Games = LoadDataUtilities.LoadGamesData();
                return View();
            }
        }
    }
}