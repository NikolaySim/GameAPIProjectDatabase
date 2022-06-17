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
    public class Player : IPlayer
    {
        #region Fields
        private PlayerManagementService service = new PlayerManagementService();
        #endregion

        public List<PlayerDTO> GetPlayers()
        {
            return service.Get();
        }

        public PlayerDTO GetPlayerByID(int id)
        {
            return service.GetById(id);
        }

        public string PostPlayer(PlayerDTO studentDto)
        {
            if (!service.Save(studentDto))
                return "Player is not inserted";

            return "Player is inserted";
        }

        public string PutPlayer(PlayerDTO studentDto)
        {
            throw new NotImplementedException();
        }

        public string DeletePlayer(int id)
        {
            if (!service.Delete(id))
                return "Player is not deleted";

            return "Player is deleted";
        }

        public string Message()
        {
            return "The WCF service is up.";
        }

    }
}
