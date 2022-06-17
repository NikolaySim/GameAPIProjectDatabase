using ApplicationService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace FreeGameDatabasePrototype
{
    [ServiceContract]
    public interface IPlayer
    {
        [OperationContract]
        string Message();

        [OperationContract]
        List<PlayerDTO> GetPlayers();

        [OperationContract]
        PlayerDTO GetPlayerByID(int id);

        [OperationContract]
        string PostPlayer(PlayerDTO playerDto);

        [OperationContract]
        string PutPlayer(PlayerDTO playerDto);

        [OperationContract]
        string DeletePlayer(int id);
    }
}
