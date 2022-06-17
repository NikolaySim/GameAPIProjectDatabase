using ApplicationService.DTOs;
using ApplicationService.Implementations;
using ApplicationService.DTOs;
using ApplicationService.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace FreeGameDatabasePrototype
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Game : IGame
    {

        #region Fields
        private GameManagementService gameService = new GameManagementService();
        #endregion

        public string Message()
        {
            return "The WCF service is up.";
        }

        public List<GameDTO> GetGames()
        {
            return gameService.Get();
        }

        public GameDTO GetGameByID(int id)
        {
            return gameService.GetById(id);
        }

        public string PostGame(GameDTO NationalityDTO)
        {
            if (!gameService.Save(NationalityDTO))
                return "Game is not inserted";

            return "Game is inserted";
        }

        public string PutGame(GameDTO NationalityDTO)
        {
            throw new NotImplementedException();
        }

        public string DeleteGame(int id)
        {
            if (!gameService.Delete(id))
                return "Game is not deleted";

            return "Game is deleted";
        }
    }
}
