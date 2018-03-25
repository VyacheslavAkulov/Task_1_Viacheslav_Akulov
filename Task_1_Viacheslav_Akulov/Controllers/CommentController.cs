using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using BLL.Interfaces;
using Models;
using Newtonsoft.Json;

namespace Task_1_Viacheslav_Akulov.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService commentService;

        public CommentController(ICommentService commentService)
        {
            this.commentService = commentService;
        }

        [HttpPost]
        public ActionResult NewComment(string commentJson)
        {
            var comment = JsonConvert.DeserializeObject<Comment>(commentJson);

            if (comment == null)
            {
                return HttpNotFound();
            }

            this.commentService.Create(comment);

            return Json("Comment created", "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetCommnetsByGame(string gamekey)
        {
            return Json(this.commentService.GetCommnetsByGame(gamekey), "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }

       
    }
}