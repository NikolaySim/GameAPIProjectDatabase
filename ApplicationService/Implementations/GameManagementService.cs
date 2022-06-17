using System;
using Data.Context;
using Data.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationService.DTOs;
using Repository.Implementations;

namespace ApplicationService.Implementations
{
    public class GameManagementService
    {
        // private System22DBContext ctx = new System22DBContext();

        public List<GameDTO> Get()
        {
            List<GameDTO> gamesDto = new List<GameDTO>();

            /*
             * use UnitOfWork instead of ctx
            foreach (var item in ctx.Nationalities.ToList())
            {
                nationalitiesDto.Add(new NationalityDTO
                {
                    Id = item.Id,
                    Title = item.Title
                });
            }
            */

            // use UnitOfWork
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                // foreach in the NationalityRepository instead of ctx
                foreach (var item in unitOfWork.GameRepository.Get())
                {

                    gamesDto.Add(new GameDTO
                    {
                        Id = item.Id,
                        Title = item.Title,
                        Details = item.Details,
                        Genre = item.Genre,
                        ReleaseDate = item.ReleaseDate,
                        Size = item.Size,
                        Platform = item.Platform,
                        Publisher = item.Publisher

                    });

                }
            }

            return gamesDto;
        }

        public GameDTO GetById(int id)
        {
            GameDTO gameDTO = new GameDTO();

            /*
             * Use UnitOfWork instead of directly ctx
            Nationality nationality = ctx.Nationalities.Find(id);
            if (nationality != null)
            {
                nationalityDTO.Id = nationality.Id;
                nationalityDTO.Title = nationality.Title;
            }
            */

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Game game = unitOfWork.GameRepository.GetByID(id);
                if (game != null)
                {
                    gameDTO = new GameDTO
                    {
                        Id = game.Id,
                        Title = game.Title,
                        Details = game.Details,
                        Genre = game.Genre,
                        ReleaseDate = game.ReleaseDate,
                        Size = game.Size,
                        Platform = game.Platform,
                        Publisher = game.Publisher
                    };
                }
            }

            return gameDTO;
        }

        public bool Save(GameDTO gameDTO)
        {
            Game game = new Game
            {
                Title = gameDTO.Title,
                Details = gameDTO.Details,
                Genre = gameDTO.Genre,
                ReleaseDate = gameDTO.ReleaseDate,
                Size = gameDTO.Size,
                Platform = gameDTO.Platform,
                Publisher = gameDTO.Publisher
            };

            try
            {
                /*
                ctx.Nationalities.Add(Nationality);
                ctx.SaveChanges();
                */
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.GameRepository.Insert(game);
                    unitOfWork.Save();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                //Nationality nationality = ctx.Nationalities.Find(id);
                //ctx.Nationalities.Remove(nationality);
                //ctx.SaveChanges();

                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    Game game = unitOfWork.GameRepository.GetByID(id);
                    unitOfWork.GameRepository.Delete(game);
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
