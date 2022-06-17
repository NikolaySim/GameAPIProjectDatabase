  using ApplicationService.DTOs;
using ApplicationService.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Messages;

namespace WebAPI.Controllers
{
    public class GameController : ApiController
    {

        private GameManagementService gameService = new GameManagementService();


        [HttpGet]
       // [Route("api/nationality")]
        public IHttpActionResult Get()
        {
            return Json(gameService.Get());
        }


        [HttpGet]
        //[Route("api/nationality/{id}")]
        public IHttpActionResult Get(int id)
        {
            return Json(gameService.GetById(id));
        }


        [HttpPost]
        public IHttpActionResult Save(GameDTO gameDto)
        {
            if (!gameDto.Validate())
                return Json(new ResponseMessage { Code = 500, Error = "Data is not valid!" });
            ResponseMessage response = new ResponseMessage();

            if (gameService.Save(gameDto))
            {
                response.Code = 200;
                response.Body = "Game is saved.";
            }
            else
            {
                response.Code = 500;
                response.Body = "Game is not saved.";
            }

            return Json(response);
        }

        [HttpDelete]
        [Route("api/nationality/{id}")]
        public IHttpActionResult Delete(int id)
        {
            ResponseMessage response = new ResponseMessage();

            if (gameService.Delete(id))
            {
                response.Code = 200;
                response.Body = "Game is deleted.";
            }
            else
            {
                response.Code = 500;
                response.Body = "Game is not deleted.";
            }

            return Json(response);
        }
    }
}
