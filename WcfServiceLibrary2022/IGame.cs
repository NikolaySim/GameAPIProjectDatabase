using ApplicationService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace FreeGameDatabasePrototype
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IGame
    {
        [OperationContract]
        string Message();

        [OperationContract]
        List<GameDTO> GetGames();

        [OperationContract]
        GameDTO GetGameByID(int id);

        [OperationContract]
        string PostGame(GameDTO gameDto);

        [OperationContract]
        string PutGame(GameDTO gameDto);

        [OperationContract]
        string DeleteGame(int id);
    }
}