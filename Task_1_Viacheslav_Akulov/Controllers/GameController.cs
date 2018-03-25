using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using BLL.Interfaces;
using Models;
using Newtonsoft.Json;
using Task_1_Viacheslav_Akulov.Filters;

namespace Task_1_Viacheslav_Akulov.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameService gameService;

        public GameController(IGameService gameService)
        {
            this.gameService = gameService;
        }

        [OutputCache(Duration = 60, Location = OutputCacheLocation.Downstream)]
        public ActionResult Details(string key)
        {
            var game = this.gameService.Get(key);

            if (game == null)
            {
                return HttpNotFound();
            }

            return Json(game, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }

        [OutputCache(Duration = 60, Location = OutputCacheLocation.Downstream)]
        public ActionResult GetGames()
        {
            var games = this.gameService.GetAll();

            return Json(games, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Create(string gameJson)
        {

            var game = JsonConvert.DeserializeObject<Game>(gameJson);

            if (game==null)
            {
                return HttpNotFound();
            }
           this.gameService.Create(game);

            return Json("Game created", "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Update(string gameJson)
        { 
            var game = JsonConvert.DeserializeObject<Game>(gameJson);

            if (game == null)
            {
                return HttpNotFound();
            }

            this.gameService.Update(game);

            return Json($"Game {game.Key} updated", "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Remove(string gamekey)
        {

            this.gameService.Delete(gamekey);

            return Json($"Game {gamekey} removed", "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Download(string gamekey)
        {

            var game = this.gameService.Get(gamekey);

            if (game != null)
            {
                using (BinaryWriter writer = new BinaryWriter(System.IO.File.Open(Server.MapPath("~/Files/Game.dat"), FileMode.Create)))
                {
                    writer.Write($"key:{game.Key} Name: {game.Name}");
                }
                return File(Server.MapPath("~/Files/Game.dat"), "application/dat", "Game.dat");
            }

            return HttpNotFound();
        }
    }
}