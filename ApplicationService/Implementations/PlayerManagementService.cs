using ApplicationService.DTOs;
using Data.Entities;
using Repository.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Implementations
{
    public class PlayerManagementService
    {
        
        public List<PlayerDTO> Get()
        {
            List<PlayerDTO> playersDto = new List<PlayerDTO>();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                foreach (var item in unitOfWork.PlayerRepository.Get())
                {

                    playersDto.Add(new PlayerDTO
                    {
                        Id = item.Id,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        City = item.City,
                    });

                }
            }

            return playersDto;
        }

        public PlayerDTO GetById(int id)
        {
            PlayerDTO PlayerDTO = new PlayerDTO();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Player player = unitOfWork.PlayerRepository.GetByID(id);
                if (player != null)
                {
                    PlayerDTO = new PlayerDTO
                    {
                        FirstName = player.FirstName,
                        LastName = player.LastName,
                        City = player.City,
                        DOB = player.DOB,
                        // you can create a search for this object based on NationalityId and load it here
                    };
                }

            }

            return PlayerDTO;
        }

        public bool Save(PlayerDTO PlayerDTO)
        {
            // either init nationality beforehand or create a check
            // StudentDTO.Nationality == null || 


            // add additional functionality - if there is no such nationality -> create it
            // Nationality nationality = new Nationality
            // {
            //     Title = StudentDTO.Nationality.Title
            // };

            Player player = new Player
            {
                FirstName = PlayerDTO.FirstName,
                LastName = PlayerDTO.LastName,
                DOB = PlayerDTO.DOB,
                City = PlayerDTO.City,
            };

            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.PlayerRepository.Insert(player);
                    unitOfWork.Save();
                }

                //Console.WriteLine(student);
                //ctx.Students.Add(student);
                //ctx.SaveChanges();

                return true;
            }
            catch
            {
                Console.WriteLine(player);
                return false;
            }
        }

        public bool Delete(int id)
        {
            // here the DTO is just an int
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    Player player = unitOfWork.PlayerRepository.GetByID(id);
                    unitOfWork.PlayerRepository.Delete(player);
                    unitOfWork.Save();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
